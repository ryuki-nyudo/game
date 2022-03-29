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
    public GameObject gameovertxt;
    public bool HPflag;

    AudioSource audioSource;
    public AudioClip HPcaveat;
    bool hflag;
    public float audio;
    public float htimer = 5.0f;

    void Start(){
        gameovertxt.SetActive(false);
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
        if(currentHp <= 0)
        {
            gameovertxt.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void OnCollisionEnter2D(Collision2D other){
        //Enemyタグのオブジェクトに触れると発動
        if (other.gameObject.tag == "enemy" && player.attackflag == false){
            //現在のHPからダメージを引く
            currentHp = currentHp - damage;

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = (float)currentHp / (float)maxHp;
        }
        else if (other.gameObject.tag == "enemy" && player.attackflag == true){
            Destroy(other.gameObject);
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
            slider.value = (float)currentHp / (float)maxHp;
        }

        if(other.gameObject.tag == "MPitem" && timer <= pTime){
            other.gameObject.SetActive(false);
        }
    }
}