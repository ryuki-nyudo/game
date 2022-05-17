using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Air : MonoBehaviour
{
    //最大HPと現在のHP。
    public int maxAir = 100;
    public double currentAir;

    public Slider slider;

    public GameObject Fade;
    public bool Airflag;

    void Start()
    {
        slider.value = 1;
        //現在のHPを最大HPと同じに。
        currentAir = maxAir;

        Fade = GameObject.Find("AirFade");
        Airflag = false;
    }

    void Update()
    {
        if (currentAir <= maxAir && Airflag == false){
            currentAir -= 0.025;
            slider.value = (float)currentAir / (float)maxAir;
        }

        if(currentAir <= 35){
            if(Fade.GetComponent<AirFade>().alfa <= 0){
                Fade.GetComponent<AirFade>().isFadeOut = true;
            }
            if(Fade.GetComponent<AirFade>().alfa >= 0.5){
                Fade.GetComponent<AirFade>().isFadeIn = true;
            }
        }

        if(currentAir <= 0 && Airflag == false){
            Airflag = true;
            currentAir = 0;
        }
    }
}