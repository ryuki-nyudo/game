using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    float seconds;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // 物理演算をしたい場合はFixedUpdateを使うのが一般的
    void FixedUpdate()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float VerticalKey = Input.GetAxis("Vertical");

        //右入力で左向きに動く
        if (horizontalKey > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            Accel();
        }
        //左入力で左向きに動く
        else if (horizontalKey < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            Accel();
        }

        //上入力で上向きに動く
        if (VerticalKey > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x,speed);
<<<<<<< HEAD
            Accel();
=======
>>>>>>> c194c29b78e1680b617e96ed4aaa8504e1cc64bb
        }
        //下入力で下向きに動く
        else if (VerticalKey < 0)
        {
<<<<<<< HEAD
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            Accel();
=======
            rb.velocity = new Vector2(rb.velocity.x,-speed);
>>>>>>> c194c29b78e1680b617e96ed4aaa8504e1cc64bb
        }

    }

    void Accel()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed += 15;
            Invoke("Decelerate", 0.3f);
        }
    }

    void Decelerate()
    {
        speed -= 15;
    }
}