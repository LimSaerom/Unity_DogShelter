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
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;      //회전방지
    }



    private void Update()
    {
        vx = 0;             //속도 초기화
        vy = 0;
        
        timer += Time.deltaTime;


        if(timer >= 10f)                           //10초 경과 할때마다 스피드 up
        {
            moveSpeed += 0.3f;
            Debug.Log("Speed UP" + moveSpeed);
            timer = 0.0f;              //타이머 초기화
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
