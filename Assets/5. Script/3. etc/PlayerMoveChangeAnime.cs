using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveChangeAnime : MonoBehaviour
{
    public string upAnime = "";
    public string downAnime = "";
    public string rightAnime = "";
    public string leftAnime = "";

    string nowMode = "";     //현재 모드를 적용하기 위한 변수선언

    void Start()
    {
        nowMode = rightAnime;        //우측을 보는 모드로 시작
    }


    void Update()
    {
        // Input.Getkey = 키보드 상하좌우를 눌렀을때 동작을 적용하기 위한 우선작업
        if (Input.GetKey("up"))
        {
            nowMode = upAnime;
        }

        if (Input.GetKey("down"))
        {
            nowMode = downAnime;
        }

        if (Input.GetKey("right"))
        {
            nowMode = rightAnime;
        }

        if (Input.GetKey("left"))
        {
            nowMode = leftAnime;
        }
    }

    private void FixedUpdate()
    {
        //실제 키보드가 눌렸을때 동작을 실행하기 위한 작업
        GetComponent<Animator>().Play(nowMode);
    }

}