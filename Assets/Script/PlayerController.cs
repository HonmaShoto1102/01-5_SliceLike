using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public Rigidbody rbKnife;           //���͂�������Ώ�
    [SerializeField]
    private GameObject goKnife;
    public GameObject LosePanel;

    //public float upForce = 5000.0f; //������ɂ������
    //public float frontForce = 500.0f; //�O�����ɂ������
    public float upSpeed = 5000.0f; //�����
    public float frontSpeed = 500.0f; //�O����
    public bool KnifeisKinematic;
    public bool GoalFlag = true;

    public bool ConstraintsFlag = true;
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
        //rigidbody�ŃI�u�W�F�N�g�ؒf���̊O�͂ŋ������΂����Ȃ�ꍇ������ɕύX
        if (Input.GetMouseButtonDown(0))
        {
            rbKnife.isKinematic = false;

            //���ݒn�擾
            startPosition = rbKnife.transform.position;
            //�����n�_���Z�b�g
            targetPosition = rbKnife.transform.position + new Vector3(0, upForce, -frontForce);

            //�ړI�n�܂ł̋��������߂�
            distance = Vector3.Distance(startPosition, targetPosition);
            //�ړ��ʂ̕�Ԓl���v�Z
            float present_Location = (Time.time * speed) / distance;
            //�ړ�������
            goKnife.transform.position = Vector3.Lerp(startPosition, targetPosition, present_Location);

            Debug.Log("startPosition" + startPosition);
            Debug.Log("targetPosition" + targetPosition);
            Debug.Log("present_Location" + present_Location);

            //�O�ɐi�݂�����o�O�i�܂��j
            //��]�̐��m
            //���Œe�����
            //

            // transform���擾
            Transform myTransform = this.transform;
            // ���[�J�����W����ɁA���W���擾
            Vector3 localPos = myTransform.position;
            //�]���Ȉړ��Ɏc�������l��������
            startPosition = localPos;
            targetPosition = localPos;
            distance = Vector3.Distance(startPosition, targetPosition);
            goKnife.transform.position = Vector3.Lerp(startPosition, targetPosition, present_Location);
        }*/

        //rigidbody�o�[�W����
        if (ConstraintsFlag == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(rbKnife.isKinematic)
                {
                   goKnife.transform.position+= Vector3.up*0.3f;
                }
                //��(sound_jump)��炷
                audioSource.PlayOneShot(sound_jump);
             

                //Vector3 force = new Vector3(0.0f, upForce * 1.2f, -frontForce / 3);    // �͂�ݒ�
                //���C������B
                // rbKnife.AddForce(force);  // �͂�������
                Vector3 v = new Vector3(0.0f, upSpeed, -frontSpeed);
                rbKnife.velocity = v;
                slicer.MoneyFlag = false;
                slicer.OneCount = 0;
                rbKnife.isKinematic = false;
            }


            //������PlayerRotation��true�ɂ���
            if (rbKnife.isKinematic == false) KnifeisKinematic = false;
        }
        
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "paka" || collision.tag == "pica" || collision.tag == "chopp")
        {
            slicer.MoneyFlag = true;
           
        }

        if (collision.tag == "Block"||collision.tag=="Goal")
        {
            //goKnife.GetComponent<Collider>().isTrigger = false;
            rbKnife.isKinematic = true;//�����Ŋ��S�ɌŒ肳����
            if (rbKnife.isKinematic == true) KnifeisKinematic = true;//rotation�̂��߂̃t���O
            slicer.MoneyFlag = false;
        }


        if(collision.tag=="Ground")
        {
            goKnife.GetComponent<Collider>().isTrigger = false;
            ConstraintsFlag = false;
            rbKnife.constraints = RigidbodyConstraints.None;
            LosePanel.SetActive(true);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
       //goKnife.GetComponent<Collider>().isTrigger =true;//
    }
   


 

}
