using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnColSystem : MonoBehaviour
{
    /// <summary>
    /// 1. MiniGame별로 이동을 관리하는 스크립트 별도 존재 → 씬이름에 따른 초기 스피드 값 세팅
    /// 2. 캐릭터 일시정지시 애니메이터도 비활성
    /// </summary>
    /// 
    bool isPaused = false;                       //isPaused = 플레이어 움직임을 제한하기 위한 변수선언
    float pauseDuration = 1f;
    float pauseTimer = 0f;

    float originalSpeed;
    float speed;                   

    string nowScenename;                         //현재씬을 저장 할 변수 생성

    //bool StopAnime = true;




    private void Start()
    {
        nowScenename = SceneManager.GetActiveScene().name;

        if (nowScenename == "MiniGame_Run")
        {
            speed = GetComponent<PlayerMoveRun>().moveSpeed;
            Debug.Log("MiniGame_Drop speed 적용" + speed);
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Block_MDrop")                  //MiniGame_Drop에서 사용
        {
            Destroy(gameObject, 0.2f);
        }

        if(col.gameObject.tag == "Bundle" && !isPaused)                   //MiniGame_Run에서 사용 (Bundle에 tag 부착)
        {
            PausePlayer();

            isPaused = true;
        }

    }

    private void Update()
    {
        if (isPaused)
        {
            // 일시정지된 상태에서 시간이 경과하면 움직임을 다시 시작합니다.
            pauseTimer += Time.deltaTime;
            if (pauseTimer >= pauseDuration)
            {
                ResumePlayer();
                isPaused = false;
                pauseTimer = 0f;
            }
        }
    }

    void PausePlayer()
    {
        GetComponent<PlayerMoveRun>().moveSpeed = 0f;
        
        Animator playerAnimator = GetComponent<Animator>();
        playerAnimator.enabled = false;
        //StopAnime = GetComponent<Animator>();
        //StopAnime = false;
    }

    void ResumePlayer()
    {
        GetComponent<PlayerMoveRun>().moveSpeed = speed;
        Animator playerAnimator = GetComponent<Animator>();
        playerAnimator.enabled = true;

    }

}
