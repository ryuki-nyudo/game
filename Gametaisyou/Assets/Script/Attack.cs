using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour{
    GameObject Player;
    Player player;
    public AudioClip sound1;
    AudioSource audioSource;

    public bool HPflag;

    void Start(){
        Player = GameObject.Find("player");
        player = Player.GetComponent<Player>();
        audioSource = GetComponent<AudioSource>();

        HPflag = false;
    }

    //茶色木箱に当たったときの動き
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "box" && player.pflag == true){
            Destroy(other.gameObject);
            audioSource.PlayOneShot(sound1);
        }

        if(other.gameObject.tag == "itembox" && player.pflag == true){
            Destroy(other.gameObject);
            Debug.Log("siri");
            HPflag = true;
        }

        if(other.gameObject.tag == "boxb" && player.pflag == true){
            Destroy(other.gameObject);
            audioSource.PlayOneShot(sound1);
        }
    }
}
