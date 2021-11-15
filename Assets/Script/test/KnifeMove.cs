using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KnifeMove : MonoBehaviour
{
    [SerializeField]
    public Rigidbody rbKnife;           //���͂�������Ώ�
    [SerializeField]
    private GameObject goKnife;

    public float upSpeed = 5000.0f; //������ɂ������
    public float frontSpeed = 500.0f; //�O�����ɂ������
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
        //Component���擾
        audioSource = GetComponent<AudioSource>();
        rbKnife.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;

    }
    private void FixedUpdate()
    {


    }


    // Update is called once per frame
    void Update()
    {

      
        //rigidbody�o�[�W����
        if (Input.GetMouseButtonDown(0))
        {

            //��(sound_jump)��炷
            audioSource.PlayOneShot(sound_jump);

            rbKnife.isKinematic = false;

            Vector3 v = new Vector3(0.0f, upSpeed, -frontSpeed);

            // rbKnife.AddForce(force);  // �͂�������
            rbKnife.velocity = v;
            slicer.MoneyFlag = false;
            slicer.OneCount = 0;
        }


        //������PlayerRotation��true�ɂ���
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
            Debug.Log("��~");
            rbKnife.isKinematic = true;//�����Ŋ��S�ɌŒ肳����

            if (rbKnife.isKinematic == true) KnifeisKinematic = true;//rotation�̂��߂̃t���O

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

        //�O�̂��ߗ��ꂽ����Rotation���Ă΂��悤�ɂ���
        rbKnife.isKinematic = false;

    }

}
