using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiRotationGauge : MonoBehaviour
{
    public GameObject Ring2; //�Q�[�W����
    public Image GaugeRing;
    public float rate; //���l����
    private float speed = 0.3f;//�Q�[�W�̌�������

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RingMove(rate);
        GaugeRing.fillAmount -= Time.deltaTime * speed;
    }

    //�����O�̓���
    void RingMove(float gauge)
    {
        //Ring2.GetComponent<Image>().DOFillAmount(gauge, speed);//speed�̎��Ԃ������ăQ�[�W������������
    }

   
}
