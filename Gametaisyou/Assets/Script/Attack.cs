using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour{
    GameObject Player;
    Player player;
    Vector2 position;

    //ポジション取得
    public GameObject HPitem;
    public GameObject MPitem;

    void Start(){
        Player = GameObject.Find("player");
        player = Player.GetComponent<Player>();
    }

    //茶色木箱に当たったときの動き
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "box" && player.pflag == true){
            Destroy(other.gameObject);
            position = other.gameObject.transform.position;
            Instantiate(HPitem,position,Quaternion.identity);
            HPitem.gameObject.SetActive(true);
        }

        if(other.gameObject.tag == "boxb" && player.pflag == true){
            Destroy(other.gameObject);
            position = other.gameObject.transform.position;
            Instantiate(MPitem,position,Quaternion.identity);
            MPitem.gameObject.SetActive(true);
        }
    }
}
