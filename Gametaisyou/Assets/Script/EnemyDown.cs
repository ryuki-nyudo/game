using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDown : MonoBehaviour{
    public GameObject EnemyMove;
    public GameObject EnemyDownImage;

    bool Downflag;
    float DownTimer = 1.5f;
    float ECountTime;

    GameObject Player;

    void Start(){
        EnemyMove.SetActive(true);
        EnemyDownImage.SetActive(false);

        Player = GameObject.Find("Player");
        Downflag = false;
        ECountTime = 0.0f;
    }

    void Update(){
        ECountTime += Time.deltaTime;
        //enemyの位置を随時取得
        EnemyDownImage.transform.position = EnemyMove.transform.position;

        if(ECountTime >= DownTimer){
            Destroy(EnemyDownImage);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player" && Player.GetComponent<Player>().attackflag == true){
            Destroy(EnemyMove);
            EnemyDownImage.SetActive(true);
            Downflag = true;
        }
    }
}
