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

    GameObject Fade;

    void Start()
    {
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentAir = maxAir;

        //Fade = GameObject.Find("AirFade").GetComponent<AirFade>();
    }

    void FixedUpdate()
    {
        if (currentAir <= maxAir)
        {
            currentAir -= 0.01;
            slider.value = (float)currentAir / (float)maxAir; ;
        }

        // if(currentAir >= 90){
        //     Fade.isFadeIn = true;
        //     if(Fade.alfa <= 0){
        //         Fade.isFadeOut = true;
        //     }
        // }
    }
}