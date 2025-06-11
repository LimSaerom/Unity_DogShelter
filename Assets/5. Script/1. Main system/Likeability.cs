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
    /// Singleton Pattern Ȱ��
    /// 1. ����ȯ�� ����(nowLove)�� �ʱ�ȭ �Ǵ� ��Ȳ�� ����
    /// 2. ������Ʈ ���� ���� ���� ����� Goal ��ũ��Ʈ���� ���������ϵ��� ����
    /// 3. Awake() �Լ� ����� ��ũ��Ʈ���� ������ �����ϱ� ���� = �ʱ�ȭ���� �ʰ� ȣ�����ִ� ����
    ///    start�Լ��� ȣ��Ǳ� ���� ���� ��� ��ü�� ���� ȣ��!!
    /// 4. Destroy() ���� Ű���� / DontDestroyOnLoad()���� ���� Ű����
    ///    ��� ��ȯ�� ���� ������Ʈ�� ����(�ʱ�ȭ) �Ǳ� ������ ��� Ű���带 ���!!
    /// 5. �ּ� ȣ������ -10���� ������ ������ �ʱ� ȣ������ 0�̱� ����
    ///    �� ���� ���۽� ����Ǵ� ��Ȳ ���� && ȣ���� 0�̴��� 1���� ��ȸ �� �����ϱ� ����
    /// </summary>
    /// 
    public static Likeability Instance;           //static ����Ͽ� Goal��ũ��Ʈ���� �����ϵ��� instance ����

    public float nowLove;                         //Goal ��ũ��Ʈ���� ���������� ������ ����(���� ȣ����)
    float maxLove = 100f;                         //ȣ������ �ִ밪

    UnityEngine.UI.Slider LoveSlider;

    string nowScenename;                         //������� ���� �� ���� ����


    private void Awake()
    {
        if(Instance != null)                      //�����Ϸ��� ��ũ��Ʈ�� Instance�� �����ϴ��� �˻�
        {
            Destroy(gameObject);                  //Goal��ũ��Ʈ�� �̹� Likeability�� ���ӿ�����Ʈ�� ������ �ִٸ� ����(�浹����)
            return;
        }
        Instance = this;                          //this Ŭ������ ���� ��ü�� ���ϴ� Ű���� = �ڱ��ڽ��� ������ �־���
        DontDestroyOnLoad(this.gameObject);  // �� ��ȯ�� �Ǿ Instance�� �ʱ�ȭ �Ǵ� �� ����
        Debug.Log("Likeability �̱��� �ν��Ͻ� ������: " + Instance);

        Start();
        Debug.Log("LoveSlider �ʱ�ȭ �Ϸ�");

        Update();
        Debug.Log("Slider Ȱ��ȭ ���� �Ǵ� �Ϸ�");

    }

    /******* 1. ȣ���� �ʱ�ȭ *******/
    //private void InitializeSlider()                  //private void Start() ��� ���
    private void Start()
    {
        LoveSlider = GameObject.Find("likeabilitySlider")?.GetComponent<UnityEngine.UI.Slider>();       //��Ȯ�� �̸����� ã��(��� ã�°� ������)
        //LoveSlider = GameObject.FindObjectOfType<Slider>();
        //LoveSlider = GetComponent<Slider>();            //Slider UI ������ͼ� LoveSlider�� ����

        if (LoveSlider == null)
        {
            Debug.LogError("Slider�� ã�� ���߽��ϴ�.");
            return;
        }

        LoveSlider.minValue = 0f;                        //�����̴��� �ּҰ�(ȣ���� �ּҰ��� ����)
        LoveSlider.maxValue = maxLove;                      //�����̴��� �ִ밪(ȣ���� �ִ밪�� ����)

        nowLove = 10;                                    //�ʱ� ȣ���� 10���� ����
        LoveSlider.value = nowLove;                     //�����̴��� ���簪 = ȣ���� �ʱⰪ

        Debug.Log("�ʱ� ���� �Ϸ�: Slider value = " + LoveSlider.value);  //Ȯ�ο�


    }

    /******* �� ��ȯ�� ���� UI Ȱ��or��Ȱ�� *******/
    private void Update()
    {
        string nowScenename = SceneManager.GetActiveScene().name;                     //���� Ȱ��ȭ�� ���� �̸��� ������\

        if (nowScenename == "Main")
        {
            LoveSlider.gameObject.SetActive(true);
            Debug.Log("Main �� Slider Ȱ��ȭ");
            return;
        }

        if (nowScenename != "Main")
        {
            LoveSlider.gameObject.SetActive(false);
            Debug.Log("Main �� �ƴҽ� Slider ��Ȱ��ȭ");
        }

    }
    

    /******* ȣ���� ����(ȣ���� ������ ����) *******/
    public void UpdateLove()
    {
        //����Ȯ�οϷ�Ǹ� �̰ɷ� LoveSlider.value = nowLove;                       //UI Value�� ���� ���� ȣ������ �ݿ�

        if (LoveSlider == null)
        {
            Debug.Log("LoveSlider�� null�Դϴ�.");
            return;

        }

        LoveSlider.value = nowLove;

        if (nowLove == 0 || nowLove ==100)
        {
            if(nowLove ==0)
            {
                Debug.Log("ȣ���� 0 GameOver");
                SceneManager.LoadScene("GameOver");              //ȣ���� 0�Ͻ� ���ӿ��������� ��ȯ
            }

            if (nowLove == 100)
            {
                Debug.Log("ȣ���� 100 GameClear");
                SceneManager.LoadScene("GameEnding");              //ȣ���� 100�Ͻ� ���ӿ��������� ��ȯ
            }

        }

    }

    /******* ȣ���� ��� *******/
    public void LoveUP(float lup)
    {
        // lup�� ���� Goal��ũ��Ʈ���� ȣ�������� ���ڰ� �Ű������� lup������ ���Ե�
        //  �� ������ �ʱⰪ ���� ���ʿ�

        if (nowLove < maxLove)     //���� ȣ������ �ִ�ȣ���� ���� ���� ��쿡�� ȣ���� �������
        {
            nowLove += lup;       //ȣ������°� ����

            if(nowLove > maxLove)       //���� ȣ������ �ִ�ġ�� �����ߴٸ�
            {
                nowLove = maxLove;      //�ִ�ġ�� ������ ���� �����ϹǷ� �ʰ��� ����
            }
            
            Debug.Log("LoveUP ȣ��: nowLove = " + nowLove);      //Ȯ�ο�
            UpdateLove();               //UI�� ���� ȣ���� ���� ����
        }
    }


    /******* ȣ���� ���� / *******/
    public void LoveDown(float ldown)
    {
        // lup�� ���� ������ ldown�� �� ����
        if(nowLove > 0)                  //���� ȣ������ 0���� ū ���
        {
            nowLove -= ldown;            //ȣ���� ���� ����

            if(nowLove < 0 )             //ȣ������ 0���� ���� ��� = ��������
            {
                nowLove = 0;           //���� ������ ����Ǵ� ������ �� ����
            }

            Debug.Log("LoveDown ȣ��: nowLove = " + nowLove);       //Ȯ�ο�
            UpdateLove();
        }
    }
}
