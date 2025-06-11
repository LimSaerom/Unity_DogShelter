using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    public static int score = 0;           //최종값
    
    //public static int startCount = 0;
    Text scoreText;             // UI 텍스트 컴포넌트

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        scoreText.text = "Score : " + score;
    }
}
