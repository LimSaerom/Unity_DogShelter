using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveH : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed = 5f;
    float timer;

    float vx = 0;
    float vy = 0;




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;      //ȸ������
    }



    private void Update()
    {
        vx = 0;             //�ӵ� �ʱ�ȭ
        vy = 0;
        
        timer += Time.deltaTime;


        if(timer >= 10f)                           //10�� ��� �Ҷ����� ���ǵ� up
        {
            moveSpeed += 0.3f;
            Debug.Log("Speed UP" + moveSpeed);
            timer = 0.0f;              //Ÿ�̸� �ʱ�ȭ
        }

        if (Input.GetKey("right"))
        {
            vx = moveSpeed;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey("left"))
        {
            vx = -moveSpeed;
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(vx, vy);
    }

}
