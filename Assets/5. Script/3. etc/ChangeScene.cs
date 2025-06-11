using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChangeScene : MonoBehaviour
{
    public string SceneName;


    public void ChangeScen()         //��ũ��Ʈ �̸��̶� �����ؼ� �Լ����� ������
    {
        //Invoke �Լ� ���� Invoke("�Լ���",�����ð�); ��, �Լ��� �����Ǿ�� ��� ����
        Invoke("LoadNextScene", 0.5f);        //��ư Ŭ�� �� 0.5�ʰ� ����� ������ �� ��ȯ
    }

    void LoadNextScene()
    {
        GameObject Btn = GameObject.Find("EndBtn");   //UI�� �����ص� EndBtn ��ư�� ã�Ƽ� Btn�� ����

        //1. Btn ������ EndBtn�� ����� ã�� �����ߴ��� Ȯ��
        //2. Btn ������ Button�� ������Ʈ�� ������ �ִ��� Ȯ�� �� Button�� ������ �־�� UI����� ��� ����
        if (Btn != null && Btn.GetComponent<Button>() != null)          //EndBtn�� ã�� ���
        {
            if (Btn == gameObject)          //Btn������ EndBtn�̸��� ������ ��� = �ش� ��ũ��Ʈ�� ������Ʈ �� ���ӿ�����Ʈ�� �����Ѱ��� Ȯ��
            {
                Application.Quit();                         //�������Ḧ �����ϴ� �Լ�
                Debug.Log("�������� ���� Ȯ��");            //����Ƽ���ο��� ���� �����ϴ��� Ȯ���� ����

                return;            //������ ���������� �Լ��� ������������ return�� �ο�
            }

        }
        SceneManager.LoadScene(SceneName);
    }

}
