using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public PlayerController playerController;

    [SerializeField]
    public Rigidbody rbKnife;           //���͂�������Ώ�
    [SerializeField]
    private GameObject goKnife;

    private float roX;

    void Start()
    {
        
    }


    void Update()
    {
      if(playerController.KnifeisKinematic==false)
        {
           
            roX = goKnife.transform.localEulerAngles.x;//�I�u�W�F�N�g�̉�]���W�擾


            //11111111111111111111111111111111111111111111111111111111111111111111111111111111111111
            //if (roX <= 180.0f)
            //{
            //    Debug.Log("��]�F����");
            //    //�G��Ă��Ȃ��Ƃ��ɉ�]
            //    //goKife.transform.Rotate(0.8f, 0, 0, Space.World);
            //    goKnife.transform.Rotate(new Vector3(0.8f, 0, 0));//1�t���[�����Ƃ�0.5�x��]

            //}
            //else
            //{

            //    Debug.Log("��]�F�x��");
            //   // goKife.transform.Rotate(0.3f, 0, 0, Space.World);
            //    goKnife.transform.Rotate(new Vector3(0.3f, 0, 0));//1�t���[�����Ƃ�0.5�x��]
            //}
            //111111111111111111111111111111111111111111111111111111111111111111111111111111111111111


            //222222222222222222222222222222222222222222222222222222222222222222222222222222222222222
            if (roX <= 180.0f)
            {
                Debug.Log("��]�F����");
                rbKnife.AddTorque(-Vector3.right * Mathf.PI*1.2f);
                //goKnife.transform.rotation = rotation;

            }
            else
            {

                Debug.Log("��]�F�x��");
                //var rotation = Quaternion.Euler(new Vector3(10.0f*Time.deltaTime, 0f, 0f));
                //goKnife.transform.rotation = rotation;
                rbKnife.AddTorque(-Vector3.right * Mathf.PI*0.2f);
            }
            //222222222222222222222222222222222222222222222222222222222222222222222222222222222222222




        }

        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("��]�`�F�b�N�F" + roX);
            Debug.Log("Bool�`�F�b�N�F" + playerController.KnifeisKinematic);
        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        
       
    }
}
