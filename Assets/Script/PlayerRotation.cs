using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public PlayerController playerController;

    [SerializeField]
    public Rigidbody rbKnife;           //←力を加える対象
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
           
            roX = goKnife.transform.localEulerAngles.x;//オブジェクトの回転座標取得


            //11111111111111111111111111111111111111111111111111111111111111111111111111111111111111
            //if (roX <= 180.0f)
            //{
            //    Debug.Log("回転：速い");
            //    //触れていないときに回転
            //    //goKife.transform.Rotate(0.8f, 0, 0, Space.World);
            //    goKnife.transform.Rotate(new Vector3(0.8f, 0, 0));//1フレームごとに0.5度回転

            //}
            //else
            //{

            //    Debug.Log("回転：遅い");
            //   // goKife.transform.Rotate(0.3f, 0, 0, Space.World);
            //    goKnife.transform.Rotate(new Vector3(0.3f, 0, 0));//1フレームごとに0.5度回転
            //}
            //111111111111111111111111111111111111111111111111111111111111111111111111111111111111111


            //222222222222222222222222222222222222222222222222222222222222222222222222222222222222222
            if (roX <= 180.0f)
            {
                Debug.Log("回転：速い");
                rbKnife.AddTorque(-Vector3.right * Mathf.PI*1.2f);
                //goKnife.transform.rotation = rotation;

            }
            else
            {

                Debug.Log("回転：遅い");
                //var rotation = Quaternion.Euler(new Vector3(10.0f*Time.deltaTime, 0f, 0f));
                //goKnife.transform.rotation = rotation;
                rbKnife.AddTorque(-Vector3.right * Mathf.PI*0.2f);
            }
            //222222222222222222222222222222222222222222222222222222222222222222222222222222222222222




        }

        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("回転チェック：" + roX);
            Debug.Log("Boolチェック：" + playerController.KnifeisKinematic);
        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        
       
    }
}
