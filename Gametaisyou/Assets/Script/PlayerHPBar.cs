using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    //最大HPと現在のHP。
    float maxHp = 100;
    public static float initialHp;
    public static float currentHp;
    int recovery = 20;
    int MAXrecovery = 60;
    int damage = 10;
    float Airdamage = 0.02f;
    public static float start;

    public Slider slider;

    GameObject Player;
    Player player;
    GameObject Attack;
    Attack attack;

    GameObject Attackflag;
    public GameObject AirCursor;
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
    public AudioClip Muteki;
    public AudioClip BoxDestroySE;
    public AudioClip GoalItemSE;
    public AudioClip KurageSE;

    bool hflag;
    public float audio;
    public float htimer = 3.0f;

    public float MPtimer = 5.0f;
    public float MPtime;
    bool MPflag;

    public GameObject gameover;
    public GameObject KurageEffect;
    public bool Kurageflag;
    public bool gameoverflag;
    public GameObject MPitemGet;
    public GameObject AirD;

    void Start()
    {
        if (start == 0)
        {
            //現在のHPを最大HPと同じに。
            currentHp = maxHp;

            slider.value = 1;
        }
        else if (start >= 1)
        {
            initialHp = currentHp;

            slider.value = initialHp / maxHp;
        }

        Attackflag = GameObject.Find("player");

        Player = GameObject.Find("player");
        player = Player.GetComponent<Player>();

        // Item = GameObject.Find("Kai");
        // item = ItemScript.GetComponent<itemScript>();

        audioSource = GetComponent<AudioSource>();
        hflag = false;
        HPflag = false;

        gameover.SetActive(false);

        MPflag = false;
        KurageEffect.SetActive(false);
        Kurageflag = false;
        gameoverflag = false;
        MPitemGet.SetActive(false);

        AirD = GameObject.Find("player");
    }

    void Update()
    {
        pTime += Time.deltaTime;
        audio += Time.deltaTime;
        MPtime += Time.deltaTime;

        if (MPflag == true && MPtime >= MPtimer)
        {
            MPflag = false;
            MPitemGet.SetActive(false);
            //audioSource.PlayOneShot(Muteki);
            player.attackspeed -= 36;
        }

        if (currentHp <= 30)
        {
            hflag = true;
            if (hflag == true && audio >= htimer)
            {
                audioSource.PlayOneShot(HPcaveat);
                audio = 0f;
                hflag = false;
            }
        }

        if (currentHp <= 0)
        {
            gameover.SetActive(true);
            Time.timeScale = 0f;
            gameoverflag = true;
        }

        if(Kurageflag == true){
            KurageEffect.transform.position = gameObject.transform.position;
            KurageEffect.SetActive(true);
        }
        else if(Kurageflag == false){
            KurageEffect.SetActive(false);
        }

        if(AirD.GetComponent<Air>().currentAir <= 0){
            Debug.Log("Airdamage");
            currentHp = currentHp - Airdamage;
            slider.value = (float)currentHp / (float)maxHp;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        //Enemyタグのオブジェクトに触れると発動
        if (other.gameObject.tag == "enemy" && player.attackflag == false)
        {
            //現在のHPからダメージを引く
            currentHp = currentHp - damage;
            audioSource.PlayOneShot(damageSE);

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = (float)currentHp / (float)maxHp;
            Camera.main.gameObject.GetComponent<ShakeCamera>().Shake();
        }
        else if (other.gameObject.tag == "enemy2" && player.attackflag == false)
        {
            Kurageflag = true;
            currentHp = currentHp - damage;
            audioSource.PlayOneShot(KurageSE);
            slider.value = (float)currentHp / (float)maxHp;
            Camera.main.gameObject.GetComponent<ShakeCamera>().Shake();
        }
        else if (other.gameObject.tag == "enemy" && player.attackflag == true)
        {
            audioSource.PlayOneShot(DestroySE);
        }
        else if (other.gameObject.tag == "enemy2" && player.attackflag == true)
        {
            Destroy(other.gameObject);
            audioSource.PlayOneShot(DestroySE);
        }

        if (other.gameObject.tag == "itembox")
        {
            pTime = 0f;
            HPflag = true;
        }

        //itembox破壊音
        if (other.gameObject.tag == "itembox" && Attackflag.GetComponent<Player>().attackflag == true)
        {
            //Debug.Log("aaaaaaa");
            audioSource.PlayOneShot(BoxDestroySE);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HPitem" && timer <= pTime)
        {
            other.gameObject.SetActive(false);
            currentHp = currentHp + recovery;
            audioSource.PlayOneShot(HealSE);
            slider.value = (float)currentHp / (float)maxHp;
            if (currentHp > 100)
            {
                currentHp = 100;
            }
        }

        if (other.gameObject.tag == "MPitem" && timer <= pTime)
        {
            other.gameObject.SetActive(false);
            MPitemGet.SetActive(true);
            MPflag = true;
            MPtime = 0f;
            player.attackspeed += 36;
            
        }

        if(other.gameObject.tag == "MAXHPitem" && timer <= pTime){
            other.gameObject.SetActive(false);
            currentHp = currentHp + MAXrecovery;
            audioSource.PlayOneShot(HealSE);
            slider.value = (float)currentHp / (float)maxHp;
            if (currentHp > 100){
                currentHp = 100;
            }
        }

        if(other.gameObject.tag == "AirMAX"){
            Debug.Log("aaa");
            //Air回復処理
            AirCursor.GetComponent<Air>().currentAir += 70;
            //Air残量が１００以上だったら
            if(AirCursor.GetComponent<Air>().currentAir >= 100){
                AirCursor.GetComponent<Air>().currentAir = 100;
            }
            //Sliderに反映
            AirCursor.GetComponent<Air>().slider.value = (float)AirCursor.GetComponent<Air>().currentAir / (float)AirCursor.GetComponent<Air>().maxAir;
        }

        if (other.gameObject.tag == "goal" && player.goalitem == true)
        {
            start++;
        }

        if (other.gameObject.tag == "goalitem")
        {
            Debug.Log("aaaaaaa");
            audioSource.PlayOneShot(GoalItemSE);
        }
    }
}