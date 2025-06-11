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

    private void OnCollisionEnter2D(Collision2D col)   //collision ��� call
    {
        speed = -speed;   //�浹�ø��� �������� �ش�
        GetComponent<SpriteRenderer>().flipX = (speed < 0);   //speed���� -�� ��� ����(��������)

    }

}
