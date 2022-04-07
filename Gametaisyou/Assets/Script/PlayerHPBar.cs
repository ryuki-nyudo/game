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
    // GameObject Item;
    // Item item;

    public float pTime;
    public float timer = 0.5f;

    public bool HPflag;

    AudioSource audioSource;
    public AudioClip damageSE;
    public AudioClip HPcaveat;
    public AudioClip HealSE;
    public AudioClip DestroySE;
    bool hflag;
    public float audio;
    public float htimer = 3.0f;

    public float MPtimer = 1.0f;
    public float MPtime;
    bool MPflag;

    public GameObject gameover;

    void Start(){
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;

        Player = GameObject.Find("player");
        player = Player.GetComponent<Player>();

        // Item = GameObject.Find("Kai");
        // item = ItemScript.GetComponent<itemScript>();

        audioSource = GetComponent<AudioSource>();
        hflag = false;
        HPflag = false;

        gameover.SetActive(false);

        MPflag = false;
    }

    void Update(){
        pTime += Time.deltaTime;
        audio += Time.deltaTime;
        MPtime += Time.deltaTime;

        if(MPflag == true && MPtime >= MPtimer){
            MPflag = false;
            player.attackspeed -= 36;
        }

        if(currentHp <= 75){
            hflag = true;
            if(hflag == true && audio >= htimer){
                audioSource.PlayOneShot(HPcaveat);
                audio = 0f;
                hflag = false;
            }
        }

        if(currentHp <= 0){
            gameover.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void OnCollisionEnter2D(Collision2D other){
        //Enemyタグのオブジェクトに触れると発動
        if (other.gameObject.tag == "enemy" && player.attackflag == false){
            //現在のHPからダメージを引く
            currentHp = currentHp - damage;
            audioSource.PlayOneShot(damageSE);

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = (float)currentHp / (float)maxHp;
        }
        else if (other.gameObject.tag == "enemy" && player.attackflag == true){
            Destroy(other.gameObject);
            audioSource.PlayOneShot(DestroySE);
        }

        if(other.gameObject.tag == "itembox"){
            pTime = 0f;
            HPflag = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "HPitem" && timer <= pTime){
            other.gameObject.SetActive(false);
            currentHp = currentHp + recovery;
            audioSource.PlayOneShot(HealSE);
            slider.value = (float)currentHp / (float)maxHp;
        }

        if(other.gameObject.tag == "MPitem" /*&& timer <= pTime*/){
            MPflag = true;
            MPtime = 0f;
            player.attackspeed += 36;
            other.gameObject.SetActive(false);
        }
    }
}