using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed = 5f;

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

        if (Input.GetKey("right"))
        {
            vx = moveSpeed;
        }

        if (Input.GetKey("left"))
        {
            vx = -moveSpeed;
        }

        
        if (Input.GetKey("up"))
        {
            vy = moveSpeed;
        }

        if (Input.GetKey("down"))
        {
            vy = -moveSpeed;
        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(vx, vy);

    }

}
