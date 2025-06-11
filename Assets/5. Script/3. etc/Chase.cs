using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    //public string chaseName = "Dog";
    //public Transform Dog; // �÷��̾�(��)�� �Ӹ� ��ġ
    
    private Vector3 offset = new Vector3(0, 2f, 0); // �÷��̾� �Ӹ� ���� ��ġ�ϵ��� ������ ����

    void Update()
    {
        GameObject chaseObject = GameObject.Find("Dog");

        if (chaseObject != null)
        {
            //transform.position = chaseObject.transform.position + offset;
            transform.position = Camera.main.WorldToScreenPoint(chaseObject.transform.position + offset);
        }

        if (chaseObject == null)
        {
            Debug.Log("�������� ��ã����");
        }
    }
}
