using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour{
    GameObject Player;
    Player player;

    GameObject Kai;

    void Start(){
        Player = GameObject.Find("player");
        player = Player.GetComponent<Player>();
        Kai = GameObject.Find("Kai");
        Kai.gameObject.SetActive(false);
    }
    //Update is called once per frame
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "box" && player.pflag == true){
            other.gameObject.SetActive(false);
            Kai.gameObject.SetActive(true);
        }
    }
}
