using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeRotation : MonoBehaviour
{
    public Transform point;
    public bool isRotate;
    public float RotationSpeed =20f;//
    public float TapAfterSpeed =5f;//
    private float angle;
    private float RotatedAngle;
    // Start is called before the first frame update
    void Start()
    {
        isRotate = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(point.position, Vector3.right, -TapAfterSpeed * Time.deltaTime);
        if (Input.GetMouseButton(0))
        {
            isRotate = true;
        }
        if (isRotate)
        {
            angle = RotationSpeed*Time.deltaTime;
            RotatedAngle += angle;
            transform.RotateAround(point.position, Vector3.right, -angle);
            if (RotatedAngle > 360)
            {
                RotatedAngle = 0;
                isRotate = false;
            }
        }
        
    }
}
