using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour{
    GameObject Player;
    Player player;

    void Start(){
        Player = GameObject.Find("player");
        player = Player.GetComponent<Player>();
    }
    // // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.tag == "Player" && player.pflag == true){
            collider.gameObject.SetActive(false);
        }
    }
}
