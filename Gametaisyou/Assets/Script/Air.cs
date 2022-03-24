﻿using System.Collections;
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

    void Start()
    {
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentAir = maxAir;

        Fade = GameObject.Find("AirFade");
    }

    void FixedUpdate()
    {
        if (currentAir <= maxAir)
        {
            currentAir -= 0.01;
            slider.value = (float)currentAir / (float)maxAir; ;
        }

        if(currentAir <= 35){
            if(Fade.GetComponent<AirFade>().alfa <= 0){
                Fade.GetComponent<AirFade>().isFadeOut = true;
            }
            if(Fade.GetComponent<AirFade>().alfa >= 0.5){
                Fade.GetComponent<AirFade>().isFadeIn = true;
            }
        }
    }
}