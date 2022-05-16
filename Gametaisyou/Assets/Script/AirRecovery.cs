using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirRecovery : MonoBehaviour
{
    [SerializeField] public ParticleSystem AirEffect;
    public GameObject AirCursor;
    public Slider AirSlider;

    AudioSource audioSource; 
    public AudioClip SoundAir;
    // Start is called before the first frame update
    void Start(){
        AirEffect.Play();
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnParticleCollision(GameObject other){
        if(other.gameObject.tag == "Player"){
            AirCursor.GetComponent<Air>().Airflag = false;
            audioSource.PlayOneShot(SoundAir);
            Destroy(AirEffect);

            //Air回復処理
            AirCursor.GetComponent<Air>().currentAir += 30;
            //Air残量が１００以上だったら
            if(AirCursor.GetComponent<Air>().currentAir >= 100){
                AirCursor.GetComponent<Air>().currentAir = 100;
            }
            //Sliderに反映
            AirSlider.GetComponent<Air>().slider.value = (float)AirCursor.GetComponent<Air>().currentAir / (float)AirCursor.GetComponent<Air>().maxAir;
        }
    }
}
