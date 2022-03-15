
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb2d;
    private float speed;

    void Start()
    {
        speed = 5;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(input * speed, rb2d.velocity.y);

        //進行方向へ向きを変える
        if (input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}