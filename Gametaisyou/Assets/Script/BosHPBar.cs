using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI使うときは忘れずに。
using UnityEngine.UI;

public class BosHPBar : MonoBehaviour
{
    //最大HPと現在のHP。
    int maxHp = 155;
    public int currentHp;
    //Sliderを入れる
    public Slider slider;
    public int damage = 20;

    GameObject Player;
    Player player;

    public GameObject ika_ashu1;
    public GameObject ika_ashu2;
    public GameObject ika_ashu3;

    public GameObject BosSlider;

    void Start()
    {
        //Sliderを満タンにする。
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;

        Player = GameObject.Find("player");
        player = Player.GetComponent<Player>();

        ika_ashu1.SetActive(true);
        ika_ashu2.SetActive(true);
        ika_ashu3.SetActive(true);

        BosSlider.SetActive(true);
    }

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    private void OnCollisionEnter2D(Collision2D collider)
    {
        //Enemyタグのオブジェクトに触れると発動
        if (collider.gameObject.tag == "enemy" && player.attackflag == true)
        {
            //ダメージは1～100の中でランダムに決める。
            

            //現在のHPからダメージを引く
            currentHp = currentHp - damage;

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = (float)currentHp / (float)maxHp;
        }
    }

    private void Update()
    {
        if (currentHp <= 0)
        {
            ika_ashu1.SetActive(false);
            ika_ashu2.SetActive(false);
            ika_ashu3.SetActive(false);

            BosSlider.SetActive(false);
        }
    }
}