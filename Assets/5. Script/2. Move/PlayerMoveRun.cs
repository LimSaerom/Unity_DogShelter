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
    bool isjumped = false;        //���������� [isjumped] ��� �̸�����
    bool isGrounded = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;      //ȸ������
    }

    private void Update()
    {
        vx = 0;             //�ӵ� �ʱ�ȭ
        //vy = 0;

        if (Input.GetKey("right"))
        {
            vx = moveSpeed;
        }

        if (Input.GetKey("left"))
        {
            vx = -moveSpeed;
        }


        if (Input.GetKey("space"))                   //�������� �ҰŶ� ���鿡 �´������ ������ ���� ����
        {
            isjumped = true;
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(vx, rb.velocity.y);           // x�� �̵��� �����ϰ� y���� ���� �ӵ��� ����
        //rb.velocity = new Vector2(vx, vy);

        if (!isGrounded)
        {
            float gravity = 1f;
            rb.velocity += Vector2.down * gravity * Time.fixedDeltaTime; // �߷��� ������ �������� �ӵ��� ������ ��
        }

        if (isjumped)      //����Ű�� ���ȴٸ�
        {
            isjumped = false;
            rb.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Block")) // ���� ������
        {
                isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Block")) // ������ �����
        {
            isGrounded = false;
        }
    }

}