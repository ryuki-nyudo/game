using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour{
    GameObject Player;
    Player player;

    public bool HPflag;

    void Start(){
        Player = GameObject.Find("player");
        player = Player.GetComponent<Player>();
        
        HPflag = false;
    }

    //茶色木箱に当たったときの動き
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "box" && player.pflag == true){
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "itembox" && player.pflag == true){
            other.gameObject.SetActive(false);
            Debug.Log("siri");
            HPflag = true;
        }

        if(other.gameObject.tag == "boxb" && player.pflag == true){
            Destroy(other.gameObject);
        }
    }
}
