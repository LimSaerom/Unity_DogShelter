using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnColSystem : MonoBehaviour
{
    /// <summary>
    /// 1. MiniGame���� �̵��� �����ϴ� ��ũ��Ʈ ���� ���� �� ���̸��� ���� �ʱ� ���ǵ� �� ����
    /// 2. ĳ���� �Ͻ������� �ִϸ����͵� ��Ȱ��
    /// </summary>
    /// 
    bool isPaused = false;                       //isPaused = �÷��̾� �������� �����ϱ� ���� ��������
    float pauseDuration = 1f;
    float pauseTimer = 0f;

    float originalSpeed;
    float speed;                   

    string nowScenename;                         //������� ���� �� ���� ����

    //bool StopAnime = true;




    private void Start()
    {
        nowScenename = SceneManager.GetActiveScene().name;

        if (nowScenename == "MiniGame_Run")
        {
            speed = GetComponent<PlayerMoveRun>().moveSpeed;
            Debug.Log("MiniGame_Drop speed ����" + speed);
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Block_MDrop")                  //MiniGame_Drop���� ���
        {
            Destroy(gameObject, 0.2f);
        }

        if(col.gameObject.tag == "Bundle" && !isPaused)                   //MiniGame_Run���� ��� (Bundle�� tag ����)
        {
            PausePlayer();

            isPaused = true;
        }

    }

    private void Update()
    {
        if (isPaused)
        {
            // �Ͻ������� ���¿��� �ð��� ����ϸ� �������� �ٽ� �����մϴ�.
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
