using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class Goal : MonoBehaviour
{
    public static bool goal;              //������ ���� ���� �Ǵ�
    float delay = 3f;                      //�浹�ϰ� �� ��ȯ���� 2���� �ð� ������ �ֱ� ����

    float timer = 0f;             // ��� �ð�
    public float timeLimit = 30f;        // ���� �ð�(���Ӻ��� �ٸ� �ð��� �ֱ� ����)

    Likeability nowLove;               //Likeability ��ũ��Ʈ�� �����ͼ� nowLove ������ ����(ȥ�� ������ ���� Likeability���� ������ ������ �����ϰ� ����)

    //����� ���� �̹��� ���
    public Image ResultImg;
    public Text LoveUPtext;
    public Text LoveDowntext;

    void Start()
    {
        goal = false;
        nowLove = Likeability.Instance;          //Likeablilty Singleton ����

        if(nowLove == null )
        {
            Debug.Log("ȣ���� ��ũ��Ʈ ã�� ����");
        }

        else         //Ȯ�ο�
        {
            Debug.Log("ȣ���� ��ũ��Ʈ ã��: " + nowLove);
        }

        ResultImg.gameObject.SetActive(false);
    }

    private void Update()                                       //���� �ð� ���� Ŭ�������� ���� ���
    {
        GoalTF();
    }

    public void GoalTF()
    {
        if (!goal)                                              //���ѽð� �ʰ�(=goal object�� ���� �� �� ���)
        {
            timer += Time.deltaTime;                           //�����ӿ��� ���� �����ӱ��� �ɸ� �ð�(fps ������ ����)
            if (timer >= timeLimit)
            {
                goal = true;                                   //Ŭ��� ���ص� �� ��ȯ�� �ؾ� �ϹǷ� true�� ����
                LoveDownText();
                if (nowLove != null)
                {
                    Debug.Log("���� �ð� �ʰ�, ȣ���� ����");        //Ȯ�ο�
                    nowLove.LoveDown(20);                            //ȣ���� ���� �� ȣ��� ����� ���� �Ű������� �����
                }

                Invoke("LoadNextScene", delay);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D col)              //���� �ð� ���� Ŭ����
    {
        if(col.gameObject.tag == "Player" && !goal)
        {
            goal = true;                          //�������� �����ϸ�(=goal object�� ���� ���)
            LoveUpText();

            if (nowLove != null)
            {
                Debug.Log("������ ����, ȣ���� ���");        //Ȯ�ο�
                nowLove.LoveUP(30); // ȣ���� ����
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
