⚙️ Unity Version: 2021.3.14f1  
⚙️ Visual Studio 2022

![시작화면](GameView/0.GameStart.png)

![메인화면](GameView/1.Main.png)

![미니게임1](GameView/2.MiniGame_Run.png)

![미니게임2](GameView/3.MiniGame_Miro.png)

![미니게임3](GameView/4.MiniGame_Drop.png)

![호감도 100 달성시 전환되는 화면](GameView/5.GameEnding.png)

![호감도 0 달성시 전환되는 화면](GameView/6.GameOver.png)


# DogShelter

기간: 2024.05.20 ~ 2024.06.19
구성원: 1인 (개인 프로젝트)
기술 스택: C#, Unity, Visual Studio 2022
URL: https://github.com/LimSaerom/Unity_DogShelter.git

---

![image.png](image.png)

# DogShelter

2024.05.20 ~ 2024.06.19 (4주)

## 서비스 소개

유기견 보호소 방문 경험을 바탕으로 기획한 2D 육성 게임입니다. 플레이어는 미니게임을 통해 강아지와 호감도를 높이고, 그 결과에 따라 엔딩을 경험하게 됩니다. 게임을 통해 유기동물 봉사활동에 대한 이해와 관심을 유도하는 것이 목적입니다.

## 소개 영상

[https://youtu.be/8ZJSWe0BuFQ?si=LhxbXrLQGdrv5v6D](https://youtu.be/8ZJSWe0BuFQ?si=LhxbXrLQGdrv5v6D)

## 주요 기능

### ✅ 메인화면

- 게임 진행 혹은 종료를 선택 할 수 있습니다.
    - 게임 진행(미니게임 선택)
        
        ![image.png](image%201.png)
        
    - 게임 종료
        
        ![image.png](image%202.png)
        

### ✅ 호감도 시스템

![image.png](image%203.png)

- 강아지와의 호감도를 나타내는 UI(SliderBar)를 화면에 출력.
- 미니게임 결과에 따라 값이 달라집니다.
    - 게임 최초 실행시 호감도는 10으로 시작합니다.

### ✅ 미니 게임 3종 선택가능

- 유기견 보호소 방문시 주로 시행하는 봉사를 게임 형식으로 구현. 결과에 따라 호감도가 변동됩니다.
    - 게임 성공시 호감도 30 상승
    - 게임 실패시 호감도 20 하락
- UI 를 활용하여 원하는 ICON 선택시 미니게임 화면으로 돌입합니다.
- 미니 게임 종료시 다시 메인화면으로 돌아와 게임을 선택할 수 있습니다.

### ✅ 미니 게임1_Run (SNS 홍보)  :icon2:

![image.png](image%204.png)

- 장애물 달리기 형태의 미니게임 구현.
- 방향키와 스페이스바를 활용하여 이동 및 점프 기능 구현
- 장애물과 충돌시 일정시간 동작 불가.
- 승리조건 : 제한 시간안에 장애물을 넘어 골 지점 도착

### ✅ 미니 게임2_Miro (산책)  :icon3-2:

![image.png](image%205.png)

![image.png](35d4c41c-7da2-4758-8bab-56a070e0d9cb.png)

- 미로 탈출 형태의 미니게임 구현.
- 방향키를 이용하여 이동
- 승리조건 : 제한 시간안에 골 지점 도착

### ✅ 미니 게임3_Drop (밥주기)  :icon4-2:

![image.png](image%206.png)

- 하늘에서 떨어지는 아이템을 먹어 점수를 획득하는 방식의 미니게임 구현.
- 상단에서 획득 점수와 잔여시간을 확인할 수 있습니다.
- 아이템은 정상사료와 불량사료 2종으로 구현
- 방향키와 이동, 일정시간이 지나면 이동속도가 상승합니다.
- 승리조건 : 제한시간 안에 300점 달성

### ✅ 호감도 결과에 따른 엔딩 출력

- 2종의 엔딩으로 구성, 호감도 수치 달성시 엔딩화면이 자동 출력됩니다.
    
    ![image.png](image%207.png)
    

## 기술 스택

- `C#`
- `Window10`
- `Visual Studio 2022`
- `Unity2021.3.14f1`

## 아키텍처 구조

### 1. 스토리보드 / 화면설계서

![image.png](image%208.png)

![image.png](image%209.png)

![image.png](image%2010.png)

![image.png](image%2011.png)

### 2. FlowChart

![FlowChart.png](FlowChart.png)

### 3. Asset 제작

Dog, Player, Log 등 일부 게임에 맞는 에셋 제작

![정리.png](%EC%A0%95%EB%A6%AC.png)

## **기술 선정 이유**

✅ C#
Unity 에서 사용되는 언어로 Unity 활용, 게임 개발이라는 주제에 맞춰 언어를 선정하게 되었습니다. Unity 자체적인 내장함수와 호환이 되고 동시에 객체지향언어를 공부하기 위함이었습니다.?

## 트러블 슈팅 (1/2)

🚨 문제 배경

프로젝트를 여러개의 Scenes으로 구성하였고, 이 과정에서 Scenes 전환 시 호감도의 값이 초기화 되는 문제 발생.

💡 해결방법

호감도 관리 스크립트를 Singleton Pattern 적용. 스크립트를 다른 스크립트에서 호출시 초기화 되지 않고 누적 되는 것 정상 확인.

1. Debug.log() 로 미니 게임 결과에 따라 호감도 값이 변동되는지 출력 되는지 파악
    
    ```csharp
    void Start()
        {
            goal = false;
            nowLove = FindObjectOfType<Likeability>();
            //Likebility 스크립트는 동일 씬에 컴포넌트 되지 않음 → 찾기위해서는 GameObject.Find("객체명")로 찾을 수 없음
    
            if(nowLove == null )
            {
                Debug.Log("호감도 스크립트 찾지 못함");     //확인용
            }
    
        }
    ```
    
2. Singleton 적용 : 호감도 관리 스크립트(Likeability)를 Instance화 해서 호출하는 방식으로 수정
    
    ```csharp
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
        }
    ```
    
    ```csharp
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
    
        }
    ```
    

## 트러블 슈팅 (2/2)

🚨 문제 배경

호감도를 관리하는 스크립트에서 호감도를 표현하는 UI(Slider)를 찾아오지 못하는 오류 발생. 1차 오류 해결하였으나, 미니게임으로 씬 전환시에도 UI가 생성되는 문제가 추가 발생

💡 해결방법

1차 오류 : 호감도를 표현하는 UI를 2개로 분리(Button, Slider) 하고 호감도를 표현해야하는 Object에서 Slider를 직접 찾을 수 있게 자식객체로 수정.

1. 호감도 관리 스크립트에 Debug.log()를 추가하고, UI를 찾아오면 호감도가 실행되도록 함수 추가
Start() 함수에서 실행시 UI를 잘 찾아오는 것을 추가 확인하여 객체 생성순서의 문제임을 파악
    
    ```csharp
    public void UpdateLove()
        {
            //문제확인완료되면 이걸로 LoveSlider.value = nowLove;                       //UI Value의 값에 현재 호감도를 반영
    
            if (LoveSlider == null)
            {
                Debug.Log("LoveSlider가 null입니다.");
                return;
    
            }
    
            LoveSlider.value = nowLove;
    
            if (nowLove == -10)
            {
                SceneManager.LoadScene("GameOver");              //호감도 -10일시 게임오버씬으로 전환
            }
    
        }
    ```
    
2. 씬 전환시 객체가 파괴되지 않도록 호감도 스크립트가 적용된 객체의 하위 객체로 위치 변경

2차 오류 : 현재씬 정보를 가져오는 내장함수 GetActiveScene() 을 활용, Main씬인 경우에만 Slider 표기

1. 현재씬의 정보를 가져오는 내장함수 GetActiveScene() 을 활용, Main씬인 경우에만 Slider 표기
update 함수를 활용해서 계속 반복 실행하도록 지정
    
    ```csharp
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
    
            Update();        //추가
            Debug.Log("Slider 활성화 여부 판단 완료");
    
        }
        
        
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
    ```
    

## **프로젝트 성과**

- Desing Pattern 학습 및 적용
- 기획, 게임로직, 그래픽, UI 디자인 등 개발 전후 과정 경험

## **프로젝트 리뷰(회고)**

개발을 공부하고 처음 실행하는 프로젝트이다 보니 이론적으로 부족한 부분이 너무 많았다고 생각이 들었습니다. 1인 개발로 진행하여 게임 로직, 그래픽, UI 디자인 등에 도전하였습니다. 기존 게임 모작 보단 첫 프로젝트인 만큼 직접 기획하고 싶었고, 그래서 더 기술적인 부분이나 게임 진행 방식 등 알고리즘 적용에 많은 애로사항을 겪었습니다. 1개월이라는 한전된 개발 기간 동안, 구현하려는 콘텐츠의 난이도가 제 실력보다 높아 많은 도전이 있었습니다. 이로 인해 여러 기능을 충분히 구현하지 못하고, 일부 기능이 기대에 미치지 못한 점이 아쉽습니다. 관련 강의시간에 예제를 통해 학습했던 기본 기능(이동, 씬 전환, Prefab 등)을 활용하고, 또 구상한 시스템을 구축하기 위해 Desing Pattern의 개념을 공부하는 계기가 되었고, 실제로 가장 기초적인 Singleton을 적용해 볼 수 있어 좋은 경험이었다고 생각합니다.
