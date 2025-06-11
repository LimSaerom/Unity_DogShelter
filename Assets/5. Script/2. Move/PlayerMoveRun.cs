using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveRun : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed = 5f;
    public float jumppower = 2f;
    

    float vx = 0;
    //float vy = 0;
    bool isjumped = false;        //관례적으로 [isjumped] 라고 이름붙임
    bool isGrounded = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;      //회전방지
    }

    private void Update()
    {
        vx = 0;             //속도 초기화
        //vy = 0;

        if (Input.GetKey("right"))
        {
            vx = moveSpeed;
        }

        if (Input.GetKey("left"))
        {
            vx = -moveSpeed;
        }


        if (Input.GetKey("space"))                   //이중점프 할거라 지면에 맞닿았을때 조건은 넣지 않음
        {
            isjumped = true;
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(vx, rb.velocity.y);           // x축 이동은 유지하고 y축은 현재 속도를 유지
        //rb.velocity = new Vector2(vx, vy);

        if (!isGrounded)
        {
            float gravity = 1f;
            rb.velocity += Vector2.down * gravity * Time.fixedDeltaTime; // 중력을 적용해 떨어지는 속도를 빠르게 함
        }

        if (isjumped)      //점프키가 눌렸다면
        {
            isjumped = false;
            rb.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Block")) // 땅에 닿으면
        {
                isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Block")) // 땅에서 벗어나면
        {
            isGrounded = false;
        }
    }

}