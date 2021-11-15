using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KnifeMove : MonoBehaviour
{
    [SerializeField]
    public Rigidbody rbKnife;           //←力を加える対象
    [SerializeField]
    private GameObject goKnife;

    public float upSpeed = 5000.0f; //上方向にかける力
    public float frontSpeed = 500.0f; //前方向にかける力
    public float Startspeed = 1.0f;
    public float speedMax = 1.0f;
    public bool KnifeisKinematic;
    public bool GoalFlag = true;


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
        rbKnife.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;

    }
    private void FixedUpdate()
    {


    }


    // Update is called once per frame
    void Update()
    {

      
        //rigidbodyバージョン
        if (Input.GetMouseButtonDown(0))
        {

            //音(sound_jump)を鳴らす
            audioSource.PlayOneShot(sound_jump);

            rbKnife.isKinematic = false;

            Vector3 v = new Vector3(0.0f, upSpeed, -frontSpeed);

            // rbKnife.AddForce(force);  // 力を加える
            rbKnife.velocity = v;
            slicer.MoneyFlag = false;
            slicer.OneCount = 0;
        }


        //ここでPlayerRotationをtrueにする
        if (rbKnife.isKinematic == false) KnifeisKinematic = false;


    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "paka" || collision.tag == "pica" || collision.tag == "chopp")
        {
            slicer.MoneyFlag = true;
        }

        if (collision.tag == "Block" || collision.tag == "Goal")
        {
            Debug.Log("停止");
            rbKnife.isKinematic = true;//ここで完全に固定させる

            if (rbKnife.isKinematic == true) KnifeisKinematic = true;//rotationのためのフラグ

            slicer.MoneyFlag = false;

            //if(collision.tag=="Goal")
            //{
            //    if(GoalFlag==true)
            //    {

            //        GoalFlag = false;
            //    }

            //}
        }
    }

    private void OnCollisionExit(Collision col)
    {

        //念のため離れた時にRotationが呼ばれるようにする
        rbKnife.isKinematic = false;

    }

}
