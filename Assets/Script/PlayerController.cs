using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public Rigidbody rbKnife;           //←力を加える対象
    [SerializeField]
    private GameObject goKnife;
    public GameObject LosePanel;

    public float upForce = 5000.0f; //上方向にかける力
    public float frontForce = 500.0f; //前方向にかける力
    public float speed = 1.0f; // スピード
    public bool KnifeisKinematic;
    public bool GoalFlag = true;

    private bool ConstraintsFlag = true;
    private float distance;
    private Vector3 startPosition, targetPosition;
   
    public AudioClip sound_jump;
    AudioSource audioSource;
    public Slicer slicer;

   

    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        ConstraintsFlag = true;

    }
    private void FixedUpdate()
    {
        if (ConstraintsFlag == true)
        {
            rbKnife.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;
        }
    }


    // Update is called once per frame
    void Update()
    {

        /*
        //rigidbodyでオブジェクト切断時の外力で挙動が可笑しくなる場合こちらに変更
        if (Input.GetMouseButtonDown(0))
        {
            rbKnife.isKinematic = false;

            //現在地取得
            startPosition = rbKnife.transform.position;
            //到着地点をセット
            targetPosition = rbKnife.transform.position + new Vector3(0, upForce, -frontForce);

            //目的地までの距離を求める
            distance = Vector3.Distance(startPosition, targetPosition);
            //移動量の補間値を計算
            float present_Location = (Time.time * speed) / distance;
            //移動させる
            goKnife.transform.position = Vector3.Lerp(startPosition, targetPosition, present_Location);

            Debug.Log("startPosition" + startPosition);
            Debug.Log("targetPosition" + targetPosition);
            Debug.Log("present_Location" + present_Location);

            //前に進みすぎるバグ（まだ）
            //回転の正確
            //柄で弾かれる
            //

            // transformを取得
            Transform myTransform = this.transform;
            // ローカル座標を基準に、座標を取得
            Vector3 localPos = myTransform.position;
            //余分な移動に残った数値を初期化
            startPosition = localPos;
            targetPosition = localPos;
            distance = Vector3.Distance(startPosition, targetPosition);
            goKnife.transform.position = Vector3.Lerp(startPosition, targetPosition, present_Location);
        }*/

        //rigidbodyバージョン
        if (ConstraintsFlag == true)
        {
            if (Input.GetMouseButtonDown(0))
            {

                //音(sound_jump)を鳴らす
                audioSource.PlayOneShot(sound_jump);

                rbKnife.isKinematic = false;
                Vector3 force = new Vector3(0.0f, upForce * 1.2f, -frontForce / 3);    // 力を設定
                                                                                       //↑修正する。
                rbKnife.AddForce(force);  // 力を加える

                slicer.MoneyFlag = false;
                slicer.OneCount = 0;
            }


            //ここでPlayerRotationをtrueにする
            if (rbKnife.isKinematic == false) KnifeisKinematic = false;
        }
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //     Debug.Log("触れた");
    //     //ここで完全に固定させる
    //     rbKnife.isKinematic = true;
    //}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "paka" || collision.tag == "pica" || collision.tag == "chopp")
        {
            slicer.MoneyFlag = true;
        }

        if (collision.tag == "Block"||collision.tag=="Goal")
        {
             Debug.Log("停止");
            rbKnife.isKinematic = true;//ここで完全に固定させる
            
            if(rbKnife.isKinematic == true) KnifeisKinematic = true;//rotationのためのフラグ

            slicer.MoneyFlag = false;
        }

        if(collision.tag=="Ground")
        {
            ConstraintsFlag = false;
            rbKnife.constraints = RigidbodyConstraints.None;
            LosePanel.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision col)
    {
       
        //念のため離れた時にRotationが呼ばれるようにする
       // rbKnife.isKinematic = false;
       
    }

}
