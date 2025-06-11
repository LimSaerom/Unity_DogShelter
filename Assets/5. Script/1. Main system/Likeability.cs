using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine.Rendering;

public class Likeability : MonoBehaviour
{
    /// <summary>
    /// Singleton Pattern 활용
    /// 1. 씬전환시 변수(nowLove)가 초기화 되는 상황을 방지
    /// 2. 컴포넌트 되지 않은 씬에 적용된 Goal 스크립트에서 참조가능하도록 관리
    /// 3. Awake() 함수 사용은 스크립트간의 참조를 설정하기 위함 = 초기화되지 않고 호출해주는 역할
    ///    start함수가 호출되기 전에 씬에 모든 객체에 대해 호출!!
    /// 4. Destroy() 삭제 키워드 / DontDestroyOnLoad()삭제 제외 키워드
    ///    →씬 전환시 게임 오브젝트가 삭제(초기화) 되기 때문에 상단 키워드를 사용!!
    /// 5. 최소 호감도를 -10으로 설정한 이유는 초기 호감도가 0이기 때문
    ///    → 게임 시작시 종료되는 상황 방지 && 호감도 0이더라도 1번의 기회 더 제공하기 위함
    /// </summary>
    /// 
    public static Likeability Instance;           //static 사용하여 Goal스크립트에서 접근하도록 instance 선언

    public float nowLove;                         //Goal 스크립트에서 실질적으로 접근할 변수(현재 호감도)
    float maxLove = 100f;                         //호감도의 최대값

    UnityEngine.UI.Slider LoveSlider;

    string nowScenename;                         //현재씬을 저장 할 변수 생성


    private void Awake()
    {
        if(Instance != null)                      //접근하려는 스크립트에 Instance가 존재하는지 검사
        {
            Destroy(gameObject);                  //Goal스크립트에 이미 Likeability를 게임오브젝트로 가지고 있다면 삭제(충돌방지)
            return;
        }
        Instance = this;                          //this 클래스의 현재 객체를 뜻하는 키워드 = 자기자신을 값으로 넣어줌
        DontDestroyOnLoad(this.gameObject);  // 씬 전환이 되어도 Instance가 초기화 되는 걸 방지
        Debug.Log("Likeability 싱글톤 인스턴스 생성됨: " + Instance);

        Start();
        Debug.Log("LoveSlider 초기화 완료");

        Update();
        Debug.Log("Slider 활성화 여부 판단 완료");

    }

    /******* 1. 호감도 초기화 *******/
    //private void InitializeSlider()                  //private void Start() 대신 사용
    private void Start()
    {
        LoveSlider = GameObject.Find("likeabilitySlider")?.GetComponent<UnityEngine.UI.Slider>();       //정확한 이름으로 찾기(계속 찾는걸 실패함)
        //LoveSlider = GameObject.FindObjectOfType<Slider>();
        //LoveSlider = GetComponent<Slider>();            //Slider UI 가지고와서 LoveSlider에 적용

        if (LoveSlider == null)
        {
            Debug.LogError("Slider를 찾지 못했습니다.");
            return;
        }

        LoveSlider.minValue = 0f;                        //슬라이더의 최소값(호감도 최소값과 동일)
        LoveSlider.maxValue = maxLove;                      //슬라이더의 최대값(호감도 최대값과 동일)

        nowLove = 10;                                    //초기 호감도 10으로 시작
        LoveSlider.value = nowLove;                     //슬라이더의 현재값 = 호감도 초기값

        Debug.Log("초기 설정 완료: Slider value = " + LoveSlider.value);  //확인용


    }

    /******* 씬 전환에 따른 UI 활성or비활성 *******/
    private void Update()
    {
        string nowScenename = SceneManager.GetActiveScene().name;                     //현재 활성화된 씬의 이름을 가져옴\

        if (nowScenename == "Main")
        {
            LoveSlider.gameObject.SetActive(true);
            Debug.Log("Main 씬 Slider 활성화");
            return;
        }

        if (nowScenename != "Main")
        {
            LoveSlider.gameObject.SetActive(false);
            Debug.Log("Main 씬 아닐시 Slider 비활성화");
        }

    }
    

    /******* 호감도 갱신(호감도 누적을 위함) *******/
    public void UpdateLove()
    {
        //문제확인완료되면 이걸로 LoveSlider.value = nowLove;                       //UI Value의 값에 현재 호감도를 반영

        if (LoveSlider == null)
        {
            Debug.Log("LoveSlider가 null입니다.");
            return;

        }

        LoveSlider.value = nowLove;

        if (nowLove == 0 || nowLove ==100)
        {
            if(nowLove ==0)
            {
                Debug.Log("호감도 0 GameOver");
                SceneManager.LoadScene("GameOver");              //호감도 0일시 게임오버씬으로 전환
            }

            if (nowLove == 100)
            {
                Debug.Log("호감도 100 GameClear");
                SceneManager.LoadScene("GameEnding");              //호감도 100일시 게임엔딩씬으로 전환
            }

        }

    }

    /******* 호감도 상승 *******/
    public void LoveUP(float lup)
    {
        // lup의 값은 Goal스크립트에서 호출했을때 인자가 매개변수인 lup변수에 대입됨
        //  → 별도의 초기값 선언 불필요

        if (nowLove < maxLove)     //현재 호감도가 최대호감도 보다 작은 경우에만 호감도 상승적용
        {
            nowLove += lup;       //호감도상승값 대입

            if(nowLove > maxLove)       //현재 호감도가 최대치에 도달했다면
            {
                nowLove = maxLove;      //최대치와 동일한 값을 대입하므로 초과를 방지
            }
            
            Debug.Log("LoveUP 호출: nowLove = " + nowLove);      //확인용
            UpdateLove();               //UI에 현재 호감도 정보 대입
        }
    }


    /******* 호감도 감소 / *******/
    public void LoveDown(float ldown)
    {
        // lup과 같은 이유로 ldown의 값 생략
        if(nowLove > 0)                  //현재 호감도가 0보다 큰 경우
        {
            nowLove -= ldown;            //호감도 감소 적용

            if(nowLove < 0 )             //호감도가 0보다 작은 경우 = 게임종료
            {
                nowLove = 0;           //최종 게임이 종료되는 시점의 값 대입
            }

            Debug.Log("LoveDown 호출: nowLove = " + nowLove);       //확인용
            UpdateLove();
        }
    }
}
