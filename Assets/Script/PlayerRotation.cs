using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public PlayerController playerController;
    public float RotationSpeed = 18f;
    public float SlowRotationSpeed = 3f;
    public float roX;
    public float speed=0.1f;
    public float targetAngle = 0.001f;
    [SerializeField]
    public Rigidbody rbKnife;           //←力を加える対象
    [SerializeField]
    private GameObject goKnife;
    private bool isStart = false;
    private bool isFall = false;
    private bool isCutting = false;
    void Start()
    {
       rbKnife.maxAngularVelocity = RotationSpeed;//maxAngularVelocityは初期値が7
       //Time.timeScale = 0;
       isStart = false;
     
        
    }

   

    void Update()
    {


        roX = GetInpectorEulersX(rbKnife.transform);//オブジェクトの回転座標取得
        //roX = goKnife.transform.localEulerAngles.x;//localEulerAnglesを使うと、ジンバルロック問題が出る

        if(rbKnife.velocity.y>0)
        {
            isFall = false;
        }
        else
        {
            isFall = true;
        }

        if (Input.GetMouseButtonDown(0))
        {

            isCutting = false;
            rbKnife.AddTorque(-Vector3.right * 500 * Mathf.PI);
        
            //rbKnife.maxAngularVelocity = RotationSpeed;
            isStart = true;
         
        }
       
        if(!isCutting)
        {
            if (isFall)
            {
                if ((roX < 135) && (roX > -15))
                {
                    float speed = RotationSpeed;
                    speed -= 3f;
                    if (speed <= SlowRotationSpeed)
                    {
                        speed = SlowRotationSpeed;
                    }
                    rbKnife.maxAngularVelocity = speed;

                }
                else
                {
                    float speed = RotationSpeed;
                    speed += 0.01f;
                    if (speed >= RotationSpeed * 1.1f)
                    {
                        speed = RotationSpeed * 1.1f;
                    }
                    rbKnife.maxAngularVelocity = speed;
                    rbKnife.AddTorque(-Vector3.right * 500 * Mathf.PI);
                }
            }
            else
            {
                rbKnife.maxAngularVelocity = RotationSpeed;
            }
        }
        else
        {
           rbKnife.angularVelocity = Vector3.zero;
                rbKnife.maxAngularVelocity = 0;
            
        }
        
            
        
        
      


        if (isStart)
        {
            Time.timeScale = 1;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "paka" || collision.tag == "pica" || collision.tag == "chopp")
        {
           
            isCutting = true;
        }
        if (collision.tag == "Block" || collision.tag == "Goal")
        {
            rbKnife.maxAngularVelocity = RotationSpeed;
            isCutting = false;

        }


    }
   


    private float GetInpectorEulersX(Transform mTransform)
    {
        Vector3 angle = mTransform.eulerAngles;
        float x = angle.x;
        

        if (Vector3.Dot(mTransform.up, Vector3.up) >= 0f)
        {
            if (angle.x >= 0f && angle.x <= 90f)
            {
                x = angle.x;
            }
            if (angle.x >= 270f && angle.x <= 360f)
            {
                x = angle.x - 360f;
            }
        }
        if (Vector3.Dot(mTransform.up, Vector3.up) < 0f)
        {
            if (angle.x >= 0f && angle.x <= 90f)
            {
                x = 180 - angle.x;
            }
            if (angle.x >= 270f && angle.x <= 360f)
            {
                x = 180 - angle.x;
            }
        }


        float roX = Mathf.Round(x);

        return roX;
    }

}
