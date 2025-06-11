using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    //public string chaseName = "Dog";
    //public Transform Dog; // 플레이어(개)의 머리 위치
    
    private Vector3 offset = new Vector3(0, 2f, 0); // 플레이어 머리 위에 위치하도록 오프셋 설정

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
            Debug.Log("강아지를 못찾는중");
        }
    }
}
