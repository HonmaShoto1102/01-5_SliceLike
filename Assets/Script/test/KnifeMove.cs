using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KnifeMove : MonoBehaviour
{

    [SerializeField]
    private Rigidbody rbKnife;           //���͂�������Ώ�
    [SerializeField]
    private GameObject goKnife;
    public float upForce = 5000.0f; //������ɂ������
    public float frontForce = 500.0f; //�O�����ɂ������


    private float distance;
    private Vector3 startPosition, targetPosition;
    // �X�s�[�h
    public float speed = 1.0F;

    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //Component���擾
        audioSource = GetComponent<AudioSource>();


    }
    private void FixedUpdate()
    {
        rbKnife.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX;

    }


    // Update is called once per frame
    void Update()
    {
       

        //rigidbody�o�[�W����
        if (Input.GetMouseButtonDown(0))
        {
            //��(sound1)��炷
            audioSource.PlayOneShot(sound1);

            rbKnife.isKinematic = false;
            Vector3 force = new Vector3(0.0f, upForce * 1.2f, -frontForce/3);    // �͂�ݒ�
            rbKnife.AddForce(force);  // �͂�������
            Debug.Log("�����ɓ����Ă�H");
        }


        if (rbKnife.isKinematic == false)
        {
            float roX = goKnife.transform.localEulerAngles.x;//�I�u�W�F�N�g�̉�]���W�擾

            if (roX <= 180.0f)
            {
                Debug.Log("��]�F����");
                //�G��Ă��Ȃ��Ƃ��ɉ�]
                //goKife.transform.Rotate(0, 0, 0.5f, Space.World);
                goKnife.transform.Rotate(new Vector3(0.8f, 0, 0));//1�t���[�����Ƃ�0.5�x��]
            }
            else
            {

                Debug.Log("��]�F�x��");
                //goKife.transform.Rotate(0, 0, 2.0f, Space.World);
                goKnife.transform.Rotate(new Vector3(0.3f, 0, 0));//1�t���[�����Ƃ�0.5�x��]
            }



        }
       

        if (Input.GetMouseButtonDown(1))
        {
           
            Debug.Log("��]�F");
          //  Debug.Log("���n�FtargetPosition" + targetPosition);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.tag == "Block")
    //    {
    //        Debug.Log("�G�ꂽ");
    //        //�����Ŋ��S�ɌŒ肳����
    //        rbKnife.isKinematic = true;
    //    }
    //}

    void OnTriggerEnter(Collider collision)
    {
        
        if (collision.tag == "Block"||collision.tag=="Goal")
        {
           Debug.Log("Block�ƐڐG");
            //�����Ŋ��S�ɌŒ肳����
            rbKnife.isKinematic = true;
        }

    }

}
