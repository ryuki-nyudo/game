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
    GameObject Attack;
    Attack attack;

    public float pTime;
    public float timer = 0.5f;

    AudioSource audioSource;
    public AudioClip HPcaveat;
    public AudioClip eDown;
    public AudioClip Rest;
    public AudioClip Damage;
    bool hflag;
    public float audio;
    public float htimer = 5.0f;

    void Start(){
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;

        Player = GameObject.Find("player");
        player = Player.GetComponent<Player>();

        audioSource = GetComponent<AudioSource>();
        hflag = false;

    }

    void Update(){
        pTime += Time.deltaTime;
        audio += Time.deltaTime;

        if(currentHp <= 75){
            hflag = true;
            if(hflag == true && audio >= htimer){
                audioSource.PlayOneShot(HPcaveat);
                audio = 0f;
                hflag = false;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D other){
        //Enemyタグのオブジェクトに触れると発動
        if (other.gameObject.tag == "enemy" && player.pflag == false){

            //現在のHPからダメージを引く
            currentHp = currentHp - damage;
            audioSource.PlayOneShot(Damage);

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = (float)currentHp / (float)maxHp;
        }
        else if (other.gameObject.tag == "enemy" && player.pflag == true){
            Destroy(other.gameObject);
            audioSource.PlayOneShot(eDown);
        }

        if(other.gameObject.tag == "itembox" || other.gameObject.tag == "boxb"){
            pTime = 0f;
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "HPitem" && timer <= pTime){
            currentHp = currentHp + recovery;
            audioSource.PlayOneShot(Rest);
            slider.value = (float)currentHp / (float)maxHp;
        }

        if(other.gameObject.tag == "MPitem" && timer <= pTime){
            other.gameObject.SetActive(false);
        }
    }
}