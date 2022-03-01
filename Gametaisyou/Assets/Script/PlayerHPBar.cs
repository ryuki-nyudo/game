using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    //最大HPと現在のHP。
    int maxHp = 100;
    int currentHp;
    int recovery = 30;
    int damage = 10;

    public Slider slider;

    GameObject Player;
    Player player;

    public float pTime;
    float timer = 0.5f;

    void Start(){
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;

        Player = GameObject.Find("player");
        player = Player.GetComponent<Player>();
    }

    void Update(){
        pTime += Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other){
        //Enemyタグのオブジェクトに触れると発動
        if (other.gameObject.tag == "enemy" && player.pflag == false){

            //現在のHPからダメージを引く
            currentHp = currentHp - damage;

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = (float)currentHp / (float)maxHp;
        }
        else if (other.gameObject.tag == "enemy" && player.pflag == true){
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.tag == "box"){
            pTime = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "item" && timer <= pTime){
            other.gameObject.SetActive(false);
            currentHp = currentHp + recovery;
            slider.value = (float)currentHp / (float)maxHp;
        }
    }
}