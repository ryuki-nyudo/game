using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirRecovery : MonoBehaviour
{
    [SerializeField] public ParticleSystem AirEffect;
    public GameObject AirCursor;
    // Start is called before the first frame update
    
    AudioSource audioSource; 
    public AudioClip Sound1;

    void Start(){
        AirEffect.Play();
    }
    
    void OnParticleCollision(GameObject other){
        if(other.gameObject.tag == "Player"){
            audioSource.PlayOneShot(Sound1);
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
