using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveChangeAnime : MonoBehaviour
{
    public string upAnime = "";
    public string downAnime = "";
    public string rightAnime = "";
    public string leftAnime = "";

    string nowMode = "";     //���� ��带 �����ϱ� ���� ��������

    void Start()
    {
        nowMode = rightAnime;        //������ ���� ���� ����
    }


    void Update()
    {
        // Input.Getkey = Ű���� �����¿츦 �������� ������ �����ϱ� ���� �켱�۾�
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
        //���� Ű���尡 �������� ������ �����ϱ� ���� �۾�
        GetComponent<Animator>().Play(nowMode);
    }

}