using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TotalMoney : MonoBehaviour
{
    
    public int MoneyScore; //���_�̕ϐ�
    public TextMeshProUGUI TotalScoreText; //���_�̕����̕ϐ�
    
    
   
    
    

    // Start is called before the first frame update
    void Start()
    {
        MoneyScore = 0; //���_��0�ɂ���
    }

    // Update is called once per frame
    void Update()
    {
        TotalScoreText.text = "$ " + MoneyScore.ToString(); //TotalScoreText�̕�����"���p�X�y�[�X�{Score"�̒l�ɂ���
        
    }
}
