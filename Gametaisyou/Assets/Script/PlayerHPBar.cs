using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    //最大HPと現在のHP。
    int maxHp = 100;
    int currentHp;

    public Slider slider;

    void Start(){
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentHp = maxHp;
    }

    private void OnTriggerEnter2D(Collider2D collider){
        //Enemyタグのオブジェクトに触れると発動
        if (collider.gameObject.tag == "enemy"){
            int damage = 10;

            //現在のHPからダメージを引く
            currentHp = currentHp - damage;

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
            slider.value = (float)currentHp / (float)maxHp; ;
        }
    }
}