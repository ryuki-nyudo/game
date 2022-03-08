using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemScript : MonoBehaviour
{
    GameObject Player;
    Player player;
    GameObject Attack;
    Attack attack;

    public float iTime;
    public float timer = 0.5f;
    public float jTime;

    public bool iflag = false;

    void Start(){
        Player = GameObject.Find("player");
        player = Player.GetComponent<Player>();
        Attack = GameObject.Find("player");
        attack = Attack.GetComponent<Attack>();

        //最初は見えなくする
        gameObject.SetActive(false);
    }

    void Update (){
        iTime += Time.deltaTime;
        if(iflag == true && jTime <= 3f){
            jTime += Time.deltaTime;
        }
        else if(iflag == true && jTime > 3f){
            iflag = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D player){
        if(player.gameObject.tag == "box"|| player.gameObject.tag == "boxb"){
            iTime = 0f;
        }
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "player" && timer <= iTime){
            iflag = true;
            jTime = 0f;
        }
    }
}
