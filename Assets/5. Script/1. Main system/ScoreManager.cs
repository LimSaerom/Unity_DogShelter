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
    public int addScore = 10;                  //�������� �Ծ��� �� �ջ� �� ����
    public float winScore = 300;

    float delay = 3f;                      //�浹�ϰ� �� ��ȯ���� 2���� �ð� ������ �ֱ� ����

    float timer = 0f;                    // ��� �ð�
    public float timeLimit = 120f;        // ���� �ð�(���Ӻ��� �ٸ� �ð��� �ֱ� ����)
    bool hasWon = false;                  //��ǥ�޼� ���� �Ǵ��� ����

    Likeability nowLove;               //Likeability ��ũ��Ʈ�� �����ͼ� nowLove ������ ����(ȥ�� ������ ���� Likeability���� ������ ������ �����ϰ� ����)

    //����� ���� �̹��� ���
    public Image ResultImg;
    public Text LoveUPtext;
    public Text LoveDowntext;


    private void Start()
    {
        nowLove = Likeability.Instance;          //Likeablilty Singleton ����

        if (nowLove == null)
        {
            Debug.Log("ȣ���� ��ũ��Ʈ ã�� ����");
        }

        else         //Ȯ�ο�
        {
            Debug.Log("ȣ���� ��ũ��Ʈ ã��: " + nowLove);
        }

        GameResult.score = 0;

        ResultImg.gameObject.SetActive(false);
    }

    private void Update()
    {
        
        timeOver();                             //���ѽð��� �������� Ȯ���ϰ� ���� ������ ����. timeOver()�� �ܵ����� ����� ���ѽð��ʰ��� ���õ� �ڵ尡 ������� �ʴ� ���� �߻�
    }


    /********** ������ �浹�� ���� ��� **********/
    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject hideObject1 = GameObject.Find("GItem(Clone)");          //Prefabs�� Hierarchy â�� �����ɶ� Clone�� �ް� ������ ������ ����� ������Ʈ�� �̸� ���� Clone�� �ٿ������.
        GameObject hideObject2 = GameObject.Find("BItem(Clone)");

        if (col.gameObject.tag == "GoodItem")
        {
            GameResult.score += addScore;
            Destroy(hideObject1);
        }

        if (col.gameObject.tag == "BadItem")
        {
            GameResult.score -= (addScore * 2);    //20�� ����
            Destroy(hideObject2);
        }

    }


    /********** ���ѽð��� ���� ���� ��� **********/
    private void timeOver()
    {

        timer += Time.deltaTime;

        
        if (timer < timeLimit)
        {
            if (GameResult.score >= winScore && !hasWon)
            {
                LoveUpText();
                if(LoveUPtext)

                hasWon = true;                   //��ǥ�޼�
                Debug.Log("��ǥ���� �޼�, ȣ���� ���");
                nowLove.LoveUP(30); // ȣ���� ����

                Invoke("LoadNextScene", delay);          //3�� �� �� ��ȯ(Ȯ�οϷ�)
            }


        }

        if (timer >= timeLimit)
        {
            LoveDownText();
            Debug.Log("���� �ð� �ʰ�, ȣ���� ����");        //Ȯ�ο�
            nowLove.LoveDown(20);                            //ȣ���� ���� �� ȣ��� ����� ���� �Ű������� �����

            Invoke("LoadNextScene", delay);          //2�� �� �� ��ȯ
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
