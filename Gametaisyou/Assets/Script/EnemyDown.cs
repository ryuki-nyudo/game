using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDown : MonoBehaviour{
    public GameObject EnemyMove;
    public GameObject EnemyDownImage;

    float ECountTime;
    public bool Enemyflag;

    GameObject Player;

    void Start(){
        EnemyMove.SetActive(true);
        EnemyDownImage.SetActive(false);

        Player = GameObject.Find("player");

        Enemyflag = false;
    }

    void Update(){
        //enemyが攻撃されるまで場所を取得
        if(Enemyflag == false){
            EnemyDownImage.transform.position = EnemyMove.transform.position;
        }
    }

    public void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player" && Player.GetComponent<Player>().attackflag == true){
            EnemyMove.SetActive(false);
            EnemyDownImage.SetActive(true);
            ECountTime = 0.0f;
            Enemyflag = true;
        }
    }
}
