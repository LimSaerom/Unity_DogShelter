using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPPlayerMove : MonoBehaviour
{
    public float speed = 0.8f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D col)   //collision 약어 call
    {
        speed = -speed;   //충돌시마다 반전값을 준다
        GetComponent<SpriteRenderer>().flipX = (speed < 0);   //speed값이 -일 경우 실행(반전실행)

    }

}
