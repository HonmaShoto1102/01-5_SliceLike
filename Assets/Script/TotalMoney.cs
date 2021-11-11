using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TotalMoney : MonoBehaviour
{
    
    public int MoneyScore; //得点の変数
    public TextMeshProUGUI TotalScoreText; //得点の文字の変数
    
    
   
    
    

    // Start is called before the first frame update
    void Start()
    {
        MoneyScore = 0; //得点を0にする
    }

    // Update is called once per frame
    void Update()
    {
        TotalScoreText.text = "$ " + MoneyScore.ToString(); //TotalScoreTextの文字を"半角スペース＋Score"の値にする
        
    }
}
