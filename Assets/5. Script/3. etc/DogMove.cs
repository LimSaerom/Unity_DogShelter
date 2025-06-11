using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMove : MonoBehaviour
{
    float speed = -2;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;   //Z�� ȸ���Ұ�

    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        speed = -speed;   //�浹�ø��� �������� �ش�
        GetComponent<SpriteRenderer>().flipX = (speed > 0);   //speed���� -�� ��� ����(��������)
        

    }
}
