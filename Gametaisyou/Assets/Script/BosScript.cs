﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class BosScript : MonoBehaviour
{
    // 往復する長さ
    private Rigidbody2D rb;
    [SerializeField] private float _length = 1;
    private Vector3 pos;
    public float yspeed = 1;
    public float xspeed = 1;

    public float hxspeed = 1;
    public float hyspeed = 1;

    public float kxspeed = 1;
    public float kyspeed = 1;

    public bool bosflag = true;
    public bool boskougekiflag = false ;

    GameObject Player;
    Player player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = transform.position;

        Player = GameObject.Find("player");
        player = Player.GetComponent<Player>();
    }

    // 物理演算をしたい場合はFixedUpdateを使うのが一般的
    //void FixedUpdate()
    //{
    //    float horizontalKey = Input.GetAxis("Horizontal");

    //    rb.AddForce(transform.right * 10.0f);

    //    //右入力で右向きに動く
    //    if (horizontalKey > 0)
    //    {
    //        rb.AddForce(transform.right * 10.0f);
    //    }
    //    //左入力で左向きに動く
    //    else if (horizontalKey < 0)
    //    {
    //        rb.AddForce(-transform.right * 10.0f);
    //    }
    //    //ボタンを話すと止まる
    //    else
    //    {
    //        rb.velocity = Vector2.zero;
    //    }
    //}

    void Update()
    {
        //// 往復した値を時間から計算
        //var value = Mathf.PingPong(Time.time, _length);

        //// x.y座標を往復させて上下運動させる
        //transform.localPosition = new Vector3(-value, value, 0);

        //transform.position = new Vector2(pos.x, _length);

        //rb.velocity = new Vector2(rb.velocity.x, speed);


    }


    void FixedUpdate()
    {
        //攻撃されたとき足を引っ込める
        if (bosflag == false && this.transform.position.y >= -20)
        {
            transform.position += new Vector3(hxspeed, -hyspeed, 0);
            boskougekiflag = true;

        }

        Transform a = Player.transform;
        Transform b = this.transform;


        Vector3 apos = a.position;
        Vector3 bpos = b.position;

        var ax = apos.x;
        var bx = bpos.x;
        var x = bx - ax;
        var x2 = ax - bx;

        //画面外からアッパー攻撃
        if (x > -1 && x < 10 && boskougekiflag == true && this.transform.position.y <= 1)
        {
            bosflag = true;
            transform.position += new Vector3(-kxspeed, kyspeed, 0);
        }
        //else if (x2 < 10 && boskougekiflag == true && this.transform.position.y <= 1)
        //{
        //    bosflag = true;
        //    transform.position += new Vector3(-kxspeed, kyspeed, 0);
        //}


    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && player.attackflag == true)
        {
            bosflag = false;
        }
    }
}