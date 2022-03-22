using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Air : MonoBehaviour
{
    //最大HPと現在のHP。
    int maxAir = 100;
    double currentAir;

    public Slider slider;

    public GameObject Fade;
    //public Fade fade;

    void Start()
    {
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentAir = maxAir;

        Fade = GameObject.Find("AirFade");
        //fade = Fade.GetComponent<AirFade>();
    }

    void FixedUpdate()
    {
        if (currentAir <= maxAir)
        {
            currentAir -= 0.01;
            slider.value = (float)currentAir / (float)maxAir; ;
        }

        if(currentAir >= 90){
            //fade.isFadeIn = true;
            // if(fade.alfa <= 0){
            //     //fade.isFadeOut = true;
            // }
        }
    }
}