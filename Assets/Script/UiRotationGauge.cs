using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UiRotationGauge : MonoBehaviour
{
    public GameObject Ring2; //ゲージ部分
    public Image GaugeRing;
    public float rate; //数値部分
    private float speed = 0.3f;//ゲージの減少時間

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

    //リングの動き
    void RingMove(float gauge)
    {
        //Ring2.GetComponent<Image>().DOFillAmount(gauge, speed);//speedの時間をかけてゲージを減少させる
    }

   
}
