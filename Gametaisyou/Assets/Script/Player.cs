using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;

    float seconds;

    public bool iflag;

    private Rigidbody2D rb;
    public bool pflag;
    public bool slow;

    bool tap = true;
    int maxSt = 100;
    double currentSt;

    public Slider slider;

    // public GameObject MPitem;
    // MPitem key;

    void Start(){
        // MPitem = GameObject.Find("key");
        // key = MPItem.GetComponent<itemScript>();

        rb = GetComponent<Rigidbody2D>();

        iflag = false;

        pflag = false;
        slow = false;

        slider.value = 1;
        currentSt = maxSt;
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
            rb.velocity = new Vector2(rb.velocity.x, speed);

            Accel();

        }
        //下入力で下向きに動く
        else if (VerticalKey < 0)
        {

            rb.velocity = new Vector2(rb.velocity.x, -speed);
            Accel();

        }
        if (currentSt < maxSt)
        {
            currentSt += 0.09;
            slider.value = (float)currentSt / (float)maxSt; 
            if (slow == true)
            {
                speed = 1;
                currentSt += 0.35;
                slider.value = (float)currentSt / (float)maxSt; ;
                if (currentSt > 70)
                {
                    slow = false;
                    speed = 3;
                }
            }
        }
        if (currentSt < 10)
        {
            slow = true;
        }

    }

    public void Accel()
    {
        if (Input.GetKeyDown(KeyCode.Space) /*&& mpitem.iflag = false*/)
        {
            if (tap == true)
            {
                if (slow == false)
                {
                    if (currentSt >= 10)
                    {
                        int move = 10;

                        currentSt = currentSt - move;

                        slider.value = (float)currentSt / (float)maxSt; ;
                        tap = false;
                        speed += 9;
                        pflag = true;
                        Invoke("Decelerate", 0.3f);
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) /*&& mpitem.iflag = true*/)
        {
            if (tap == true)
            {
                if (slow == false)
                {
                    if (currentSt >= 10)
                    {
                        int move = 10;

                        currentSt = currentSt - move;

                        slider.value = (float)currentSt / (float)maxSt; ;
                        tap = false;
                        speed += 18;
                        pflag = true;
                        Invoke("Decelerate", 0.3f);
                    }
                }
            }
        }
    }

    void Decelerate()
    {
        //if(mpitem.iflag == fasle){
            speed -= 9;
            pflag = false;
            tap = true;
        // }
        // else if(mpitem.iflag == true){
        //     speed -= 18;
        //     pflag = false;
        //     tap = true;
        // }
    }
}