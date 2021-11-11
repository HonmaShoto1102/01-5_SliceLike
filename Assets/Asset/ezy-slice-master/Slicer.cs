using UnityEngine;
using System.Collections.Generic;
using EzySlice;
using TMPro;
public class Slicer : MonoBehaviour
{
    public Material[] materialAfterSlice;
    public LayerMask sliceMask;
    public bool isTouched;
    public int SliceNum = 0;
    public float ItemMass = 500;
    public float ItemDrag = 2;
    public float ItemAngularDrag = 0.2f;
    public float speed = 10;
    private float elapsedTime = 0.0f;
    private float PointMaxTime = 2.0f;//二秒間表示

    

    public AudioClip sound_paka,sound_chopp,sound_pica;
    AudioSource audioSource;
    public TotalMoney moneyScore;

    public Vector3 GetMoneyPointPosition;
    [SerializeField]
    private GameObject goCamera;//現在使っているカメラ
    [SerializeField]
    private GameObject goCutPoint;//プレハブの3DTextを入れる
    //生成したObjectを持っておくためのList
    List<GameObject> list_CutPoint_ = new List<GameObject>();
    List<bool> list_PointCount_ = new List<bool>();//生成したオブジェクトの判定を持っておくためのリスト
    public GameObject[] DirtSplatterParticlesPrefab;


    //ここから追加

    //private GameObject goTextInstantiate;//プレハブの3DTextを入れる
    [SerializeField]
    private GameObject goCanvas;//プレハブの3DTextを入れる

    [SerializeField]
    private TextMeshProUGUI tmTextInstantiate;//tmPopUpUITextを格納する場所
    private TextMeshProUGUI tmPopUpUIText;//プレハブの3DTextを入れる

    public bool MoneyFlag = false;//Blockに触れたらfalse
    public int OneCount;//一度に切ったオブジェクトの数を取得する
    private float PosCorrection = 5.0f;//画面上からの距離の補正
    private float PopUpTime = 0.0f;
    private bool PopUpFlag = false;//生成したらTRUE


    private void Start()
    {
        SliceNum = 0;
        OneCount = 0;
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        PointDestroy();
        PopUpUI();

        if (isTouched == true)
        {
            isTouched = false;
            Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(0.005f, 0.25f, 0.35f),
                transform.rotation, sliceMask);


            foreach (Collider objectToBeSliced in objectsToBeSliced)
            {
                SliceNum++;
                if (SliceNum > materialAfterSlice.Length - 1)
                {
                    SliceNum = 0;
                }
                GetMoneyPointPosition = objectToBeSliced.gameObject.transform.position;//切られるオブジェクトの座標を取得
                Destroy(objectToBeSliced.gameObject);
                SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, materialAfterSlice[SliceNum]);


                if (slicedObject != null)
                {
                    GameObject lower = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice[SliceNum]);
                    GameObject upper = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice[SliceNum]);
                    upper.transform.position = objectToBeSliced.transform.position;
                    lower.transform.position = objectToBeSliced.transform.position;

                    if (objectToBeSliced.tag == "paka")
                    {
                        //音(sound_paka)を鳴らす
                        audioSource.PlayOneShot(sound_paka);
                        moneyScore.MoneyScore += 1;
                        MakeParticle(GetMoneyPointPosition,0);
                        OneCount += 1;
                    }
                    if (objectToBeSliced.tag == "chopp")
                    {
                        //音(sound_chopp)を鳴らす
                        audioSource.PlayOneShot(sound_chopp);
                        moneyScore.MoneyScore += 1;
                        MakeParticle(GetMoneyPointPosition,0);
                        OneCount += 1;
                    }
                    if (objectToBeSliced.tag == "pica")
                    {
                        //音(sound_pica)を鳴らす
                        audioSource.PlayOneShot(sound_pica);
                        moneyScore.MoneyScore += 1;
                        MakeParticle(GetMoneyPointPosition,1);
                        OneCount += 1;
                    }
                    


                    MakeItPhysical(lower,  1);
                    MakeItPhysical(upper, -1);
                    
                    CutPointBone();
                    


                }
            }





        }
          

        
    }
    private void MakeItPhysical(GameObject obj, int direction)
    {
        obj.AddComponent<MeshCollider>().convex = true;

        Rigidbody rb = obj.AddComponent<Rigidbody>();
        rb.mass = ItemMass;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        // | RigidbodyConstraints.FreezeRotationY
        // | RigidbodyConstraints.FreezeRotationZ;
        rb.drag = ItemDrag;
        rb.angularDrag = ItemAngularDrag;
        Vector3 force = obj.transform.forward * speed * direction;
        rb.AddForce(force);

    }
 

    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.right, crossSectionMaterial);
    }

    private void CutPointBone()
    {
        //Cameraポジションの取得
        Vector3 camera = new Vector3(goCamera.transform.position.x, 1.0f, goCamera.transform.position.z);

        GameObject CutPointInstance= Instantiate(goCutPoint, GetMoneyPointPosition, Quaternion.LookRotation(-camera, Vector3.up));
        bool pointcount = true;

        //生成したインスタンスをリストで持っておく
        list_CutPoint_.Add(CutPointInstance);
        list_PointCount_.Add(pointcount);

    }

    private void PointDestroy()
    {

        //リストで保持しているインスタンスを削除
        for (int i = 0; i < list_CutPoint_.Count; i++)
        {
            if (list_PointCount_[i] == true)//ポイントそれぞれの判定、TRUEでポイント"+1"出現
            {
                elapsedTime += Time.deltaTime;

                if (elapsedTime >=  PointMaxTime)//PointMaxTime（２秒）超えたら消す
                {
                    Destroy(list_CutPoint_[i]);//ここで消していく
                    list_PointCount_[i] = false;//呼ばれ続けないようにする
                    elapsedTime = 0.0f;//ポイントの生存時間を初期化

                    list_CutPoint_.RemoveAt(i);//前から削除していく方が処理が重い、今回の場合は後ろから削除はできない
                    list_PointCount_.RemoveAt(i);//list_CutPoint_と同じ数だけ作られている  
                }

            }
        }
       
    }
    public void MakeParticle(Vector3 pos,int num)
    {

        GameObject spl = Instantiate(DirtSplatterParticlesPrefab[num], pos, Quaternion.identity);
        spl.GetComponent<ParticleSystem>().Play();
        Destroy(spl, 2.0f);
    }


    private void PopUpUI()
    {

        if (MoneyFlag == true)
        {
            
            Debug.Log("OneCount:" + OneCount);


            if (OneCount >= 2 && OneCount < 4)
            {
                tmTextInstantiate.text = "GOOD";
                tmPopUpUIText = Instantiate(tmTextInstantiate, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                tmPopUpUIText.transform.SetParent(goCanvas.transform, false);
                PopUpFlag = true;
                Debug.Log("GOOD:Create");
                MoneyFlag = false;
            }
            if (OneCount >= 4 && OneCount <= 9)
            {
                tmTextInstantiate.text = "NICE";
                tmPopUpUIText = Instantiate(tmTextInstantiate, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                tmPopUpUIText.transform.SetParent(goCanvas.transform, false);
                PopUpFlag = true;
                Debug.Log("NICE:Create");
                MoneyFlag = false;
            }
            if (OneCount > 9)
            {
                tmTextInstantiate.text = "AWESOME";
                tmPopUpUIText = Instantiate(tmTextInstantiate, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                tmPopUpUIText.transform.SetParent(goCanvas.transform, false);
                PopUpFlag = true;
                Debug.Log("AWESOME:Create");
                MoneyFlag = false;
            }
        }
        else
        {
            OneCount = 0;

        }

        if (PopUpFlag == true)
        {
            PopUpTime += Time.deltaTime;

            if (PopUpTime >= PointMaxTime*2.0f)
            {
                Debug.Log("消した");
                //Destroy(tmPopUpUIText);
                PopUpFlag = false;
            }
        }
    }



}
