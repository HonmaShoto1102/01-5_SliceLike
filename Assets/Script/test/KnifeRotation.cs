using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeRotation : MonoBehaviour
{
    public PlayerController playerController;
    public float RotationSpeed = 10f;
    private float roX;
    [SerializeField]
    public Rigidbody rbKnife;           //���͂�������Ώ�
    [SerializeField]
    private GameObject goKnife;
    private bool isStart = false;
    private bool isRotate = false;
    // public float roX;
    public float speed = 0.1f;
    void Start()
    {
        rbKnife.maxAngularVelocity = RotationSpeed;//maxAngularVelocity�͏����l��7�̂ŁA������Ƒ�������B
                                                   //Time.timeScale = 0;
        isStart = false;
        isRotate = false;
    }


    void Update()
    {
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(90, -180, 0), speed);
        if (Input.GetMouseButtonDown(0))
        {
            isStart = true;
            isRotate = true;
        }
        if (isStart)
        {
            Time.timeScale = 1;
        }
        if (playerController.KnifeisKinematic == false)
        {

            roX = goKnife.transform.localEulerAngles.x;//�I�u�W�F�N�g�̉�]���W�擾
            rbKnife.AddTorque(-Vector3.right * Mathf.PI * 0.001f);

            if ((roX >= 85) && (roX < 90))
            {

                //isRotate = true;


            }
            KnifeRotate();


        }
    }



    private void OnCollisionEnter(Collision collision)
    {


    }
    private void KnifeRotate()
    {
        if (isRotate)
        {
            rbKnife.AddTorque(-Vector3.right * 20 * Mathf.PI);
            isRotate = false;
        }
    }
}
