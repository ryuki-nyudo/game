using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour{
    GameObject Player;
    Player player;
    
    GameObject gameobject;

    public BoxDestroy destroy;

    public bool HPflag;

     void Start(){
        
        gameobject = GameObject.Find("woodbox");
        
        Player = GameObject.Find("player");
        player = Player.GetComponent<Player>();
        
        HPflag = false;
    }

    public void boxdestroy()
    {
        destroy.Explode();
    }

    //茶色木箱に当たったときの動き
     void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "box" && player.pflag == true){
            
            gameobject.GetComponent<BoxDestroy>().Explode();
            //boxdestroy();
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "itembox" && player.pflag == true){
            gameobject.GetComponent<BoxDestroy>().Explode();
            //boxdestroy();
            Destroy(other.gameObject);
            Debug.Log("siri");
            HPflag = true;
        }

        if(other.gameObject.tag == "boxb" && player.pflag == true){
            gameobject.GetComponent<BoxDestroy>().Explode();
            //boxdestroy();
            Destroy(other.gameObject);
        }
    }
}
