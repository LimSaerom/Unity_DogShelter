using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    public static int score = 0;           //������
    
    //public static int startCount = 0;
    Text scoreText;             // UI �ؽ�Ʈ ������Ʈ

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        scoreText.text = "Score : " + score;
    }
}
