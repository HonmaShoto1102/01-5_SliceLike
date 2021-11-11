using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KnifeMove : MonoBehaviour
{

    [SerializeField]
    private Rigidbody rbKnife;           //←力を加える対象
    [SerializeField]
    private GameObject goKnife;
    public float upForce = 5000.0f; //上方向にかける力
    public float frontForce = 500.0f; //前方向にかける力


    private float distance;
    private Vector3 startPosition, targetPosition;
    // スピード
    public float speed = 1.0F;

    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();


    }
    private void FixedUpdate()
    {
        rbKnife.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;

    }


    // Update is called once per frame
    void Update()
    {
       

        //rigidbodyバージョン
        if (Input.GetMouseButtonDown(0))
        {
            //音(sound1)を鳴らす
            audioSource.PlayOneShot(sound1);

            rbKnife.isKinematic = false;
            Vector3 force = new Vector3(0.0f, upForce * 1.2f, -frontForce/3);    // 力を設定
            rbKnife.AddForce(force);  // 力を加える
            Debug.Log("ここに入ってる？");
        }


        if (rbKnife.isKinematic == false)
        {
            float roX = goKnife.transform.localEulerAngles.x;//オブジェクトの回転座標取得

            if (roX <= 180.0f)
            {
                Debug.Log("回転：速い");
                //触れていないときに回転
                //goKife.transform.Rotate(0, 0, 0.5f, Space.World);
                goKnife.transform.Rotate(new Vector3(0.8f, 0, 0));//1フレームごとに0.5度回転
            }
            else
            {

                Debug.Log("回転：遅い");
                //goKife.transform.Rotate(0, 0, 2.0f, Space.World);
                goKnife.transform.Rotate(new Vector3(0.3f, 0, 0));//1フレームごとに0.5度回転
            }



        }
       

        if (Input.GetMouseButtonDown(1))
        {
           
            Debug.Log("回転：");
          //  Debug.Log("着地：targetPosition" + targetPosition);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.tag == "Block")
    //    {
    //        Debug.Log("触れた");
    //        //ここで完全に固定させる
    //        rbKnife.isKinematic = true;
    //    }
    //}

    void OnTriggerEnter(Collider collision)
    {
        
        if (collision.tag == "Block"||collision.tag=="Goal")
        {
           Debug.Log("Blockと接触");
            //ここで完全に固定させる
            rbKnife.isKinematic = true;
        }

    }

}
