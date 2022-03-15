using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect : MonoBehaviour{
    public GameObject enemyEffect;
    public GameObject ikasumi;
    GameObject Player;
    Player player;

    public float eTimer = 3.0f;
    public float etime;
    public bool eflag;

    void Start(){
        Player = GameObject.Find("player");
        player = Player.GetComponent<Player>();
        ikasumi.gameObject.SetActive(false);
        eflag = false;
        etime = 0.0f;
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player" && player.pflag == true){
            eflag = true;
            EEffect();
        }
    }

    void EEffect(){
        GameObject effect = Instantiate(enemyEffect) as GameObject;
        effect.transform.position = gameObject.transform.position;
    }
}