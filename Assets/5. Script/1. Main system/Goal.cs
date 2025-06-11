using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class Goal : MonoBehaviour
{
    public static bool goal;              //목적지 도착 여부 판단
    float delay = 3f;                      //충돌하고 씬 전환까지 2초의 시간 여유를 주기 위함

    float timer = 0f;             // 경과 시간
    public float timeLimit = 30f;        // 제한 시간(게임별로 다른 시간을 주기 위함)

    Likeability nowLove;               //Likeability 스크립트를 가져와서 nowLove 변수로 선언(혼동 방지를 위해 Likeability에서 선언한 변수와 동일하게 잡음)

    //결과에 따른 이미지 출력
    public Image ResultImg;
    public Text LoveUPtext;
    public Text LoveDowntext;

    void Start()
    {
        goal = false;
        nowLove = Likeability.Instance;          //Likeablilty Singleton 적용

        if(nowLove == null )
        {
            Debug.Log("호감도 스크립트 찾지 못함");
        }

        else         //확인용
        {
            Debug.Log("호감도 스크립트 찾음: " + nowLove);
        }

        ResultImg.gameObject.SetActive(false);
    }

    private void Update()                                       //제한 시간 내에 클리어하지 못한 경우
    {
        GoalTF();
    }

    public void GoalTF()
    {
        if (!goal)                                              //제한시간 초과(=goal object에 닿지 못 한 경우)
        {
            timer += Time.deltaTime;                           //프레임에서 현재 프레임까지 걸린 시간(fps 보정을 위함)
            if (timer >= timeLimit)
            {
                goal = true;                                   //클리어를 못해도 씬 전환은 해야 하므로 true로 만듦
                LoveDownText();
                if (nowLove != null)
                {
                    Debug.Log("제한 시간 초과, 호감도 감소");        //확인용
                    nowLove.LoveDown(20);                            //호감도 감소 → 호출시 사용한 값은 매개변수에 저장됨
                }

                Invoke("LoadNextScene", delay);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D col)              //제한 시간 내에 클리어
    {
        if(col.gameObject.tag == "Player" && !goal)
        {
            goal = true;                          //목적지에 도착하면(=goal object에 닿은 경우)
            LoveUpText();

            if (nowLove != null)
            {
                Debug.Log("목적지 도착, 호감도 상승");        //확인용
                nowLove.LoveUP(30); // 호감도 증가
            }

            Invoke("LoadNextScene", delay);
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
