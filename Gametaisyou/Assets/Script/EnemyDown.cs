using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDown : MonoBehaviour{
    SpriteRenderer MainSpriteRenderer;
    public Sprite EnemyMove;
    public Sprite EnemyDownImage;

    float ECountTime;
    float EnemyTimer = 2.0f;
    public bool Enemyflag;

    GameObject Player;
    public PolygonCollider2D col;

    void Start(){
        // このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        Player = GameObject.Find("player");

        Enemyflag = false;
    }

    void Update(){
        ECountTime += Time.deltaTime;
        if(Enemyflag == true && ECountTime >= EnemyTimer){
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player" && Player.GetComponent<Player>().attackflag == true){
            MainSpriteRenderer.sprite = EnemyDownImage;

            ECountTime = 0.0f;
            Enemyflag = true;
            col.enabled = false;
        }
    }
}
