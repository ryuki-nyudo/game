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

   

    void FixedUpdate()
    {
        Transform p = Player.transform;
        Transform b = this.transform;


        Vector3 ppos = p.position;
        Vector3 bpos = b.position;

        var px = ppos.x;
        var bx = bpos.x;
        var x = bx - px;
        var x2 = px - bx;


        //攻撃されたとき足を引っ込める
        if (bosflag == false && this.transform.position.y >= -20)
        {
            transform.position += new Vector3(hxspeed, -hyspeed, 0);
            if (this.transform.position.y <= -20) {
                boskougekiflag = true;
            }
        }


        //画面外からアッパー攻撃
        if (x < 20 && boskougekiflag == true && this.transform.position.y <= 0.19)
        {
            bosflag = true;
            transform.position += new Vector3(-kxspeed, kyspeed, 0);
            if (this.transform.position.y >= 0.19)
            {
                boskougekiflag = false;
            }
        }
     
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && player.attackflag == true)
        {
            bosflag = false;
        }
    }
}