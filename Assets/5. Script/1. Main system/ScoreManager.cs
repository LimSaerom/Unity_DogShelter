using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int addScore = 10;                  //아이템을 먹었을 때 합산 될 점수
    public float winScore = 300;

    float delay = 3f;                      //충돌하고 씬 전환까지 2초의 시간 여유를 주기 위함

    float timer = 0f;                    // 경과 시간
    public float timeLimit = 120f;        // 제한 시간(게임별로 다른 시간을 주기 위함)
    bool hasWon = false;                  //목표달성 여부 판단을 위함

    Likeability nowLove;               //Likeability 스크립트를 가져와서 nowLove 변수로 선언(혼동 방지를 위해 Likeability에서 선언한 변수와 동일하게 잡음)

    //결과에 따른 이미지 출력
    public Image ResultImg;
    public Text LoveUPtext;
    public Text LoveDowntext;


    private void Start()
    {
        nowLove = Likeability.Instance;          //Likeablilty Singleton 적용

        if (nowLove == null)
        {
            Debug.Log("호감도 스크립트 찾지 못함");
        }

        else         //확인용
        {
            Debug.Log("호감도 스크립트 찾음: " + nowLove);
        }

        GameResult.score = 0;

        ResultImg.gameObject.SetActive(false);
    }

    private void Update()
    {
        
        timeOver();                             //제한시간을 매프레임 확인하고 조건 만족시 실행. timeOver()를 단독으로 실행시 제한시간초과와 관련된 코드가 실행되지 않는 현상 발생
    }


    /********** 아이템 충돌에 따른 결과 **********/
    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject hideObject1 = GameObject.Find("GItem(Clone)");          //Prefabs이 Hierarchy 창에 생성될땐 Clone을 달고 나오기 때문에 사라질 오브젝트의 이름 또한 Clone을 붙여줘야함.
        GameObject hideObject2 = GameObject.Find("BItem(Clone)");

        if (col.gameObject.tag == "GoodItem")
        {
            GameResult.score += addScore;
            Destroy(hideObject1);
        }

        if (col.gameObject.tag == "BadItem")
        {
            GameResult.score -= (addScore * 2);    //20점 감소
            Destroy(hideObject2);
        }

    }


    /********** 제한시간에 따른 게임 결과 **********/
    private void timeOver()
    {

        timer += Time.deltaTime;

        
        if (timer < timeLimit)
        {
            if (GameResult.score >= winScore && !hasWon)
            {
                LoveUpText();
                if(LoveUPtext)

                hasWon = true;                   //목표달성
                Debug.Log("목표점수 달성, 호감도 상승");
                nowLove.LoveUP(30); // 호감도 증가

                Invoke("LoadNextScene", delay);          //3초 후 씬 전환(확인완료)
            }


        }

        if (timer >= timeLimit)
        {
            LoveDownText();
            Debug.Log("제한 시간 초과, 호감도 감소");        //확인용
            nowLove.LoveDown(20);                            //호감도 감소 → 호출시 사용한 값은 매개변수에 저장됨

            Invoke("LoadNextScene", delay);          //2초 후 씬 전환
        }

    }

    void LoveUpText()
    {
        ResultImg.gameObject.SetActive(true);
        LoveUPtext.gameObject.SetActive(true);
        LoveDowntext.gameObject.SetActive(false);
    }

    void LoveDownText()
    {
        ResultImg.gameObject.SetActive(true);
        LoveDowntext.gameObject.SetActive(true);
        LoveUPtext.gameObject.SetActive(false);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene("Main");
    }
}
