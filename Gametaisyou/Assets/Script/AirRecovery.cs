using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirRecovery : MonoBehaviour
{
    [SerializeField] public ParticleSystem AirEffect;
    public GameObject AirCursor;

    AudioSource audioSource; 
    public AudioClip SoundAir;
    // Start is called before the first frame update
    void Start(){
        AirEffect.Play();
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnParticleCollision(GameObject other){
        if(other.gameObject.tag == "Player"){
            audioSource.PlayOneShot(SoundAir);
            Debug.Log("Air");
            Destroy(AirEffect);

            //Air回復処理
            AirCursor.GetComponent<Air>().currentAir += 30;
            //Air残量が１００以上だったら
            if(AirCursor.GetComponent<Air>().currentAir >= 100){
                AirCursor.GetComponent<Air>().currentAir = 100;
            }
            //Sliderに反映
            AirCursor.GetComponent<Air>().slider.value = (float)AirCursor.GetComponent<Air>().currentAir / (float)AirCursor.GetComponent<Air>().maxAir;
            Debug.Log(AirCursor.GetComponent<Air>().currentAir);
        }
    }
}
