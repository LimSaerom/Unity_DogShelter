using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeLimit : MonoBehaviour
{
    public float timeLimit;           //제한시간 시작값(미니게임별로 제한 시간이 상이해 public 선언)
    Text timeText;             // UI 텍스트 컴포넌트

    void Start()
    {
        timeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;

        int timeLimitInt = Mathf.CeilToInt(timeLimit); // 소수점 이하를 올림하여 정수로 변환
        timeText.text = "TimeLimit : " + timeLimitInt.ToString(); // 소수점 이하를 버리고 정수로 변환 후 출력

        if (timeLimitInt <= 0)
        {
            timeText.text = "0";
            //제한시간이 끝나도 음수값이 출력되는 현상 발생하여 문자형으로 0 표기
        }
        if (timeLimitInt <= 0)
        {
            timeLimit = 0;           //제한시간이 끝나도 음수값이 출력되는 현상 발생하여 문자형으로 0 표기
            timeText.text = "제한시간 초과";
            //제한시간이 끝나도 음수값이 출력되는 현상 발생하여 문자형으로 0 표기
        }

    }
}
