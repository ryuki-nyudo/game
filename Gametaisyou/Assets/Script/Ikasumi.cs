using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikasumi : MonoBehaviour
{
    public GameObject ikasumi;
    GameObject Player;
    Player player;

    public float eTimer = 5.0f;
    public float etime;
    public bool eflag;

    void Start(){
        Player = GameObject.Find("player");
        player = Player.GetComponent<Player>();
        ikasumi.gameObject.SetActive(false);
        eflag = false;
        etime = 0.0f;
    }

    void Update(){
        etime += Time.deltaTime;
        if(eflag == true && etime >= eTimer){
            ikasumi.gameObject.SetActive(true);
            eflag = false;
            etime = 0.0f;
        }
        
        if(eflag == false && etime >= eTimer){
            ikasumi.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "enemy" && player.pflag == true){
            etime = 0f;
            eflag = true;
        }
    }
}