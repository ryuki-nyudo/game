
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb2d;
    private float speed;

    GameObject Player;
    Player player;

    void Start()
    {
        speed = 5;
        rb2d = GetComponent<Rigidbody2D>();

        Player = GameObject.Find("player");
        player = Player.GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        float input = Input.GetAxisRaw("Horizontal");
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