using System.Collections;
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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = transform.position;
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

        transform.position = new Vector3(pos.x - Mathf.PingPong(Time.time, _length), pos.y + Mathf.PingPong(Time.time, _length), pos.z);
    }
}