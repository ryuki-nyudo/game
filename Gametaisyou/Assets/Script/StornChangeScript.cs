using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StornChangeScript : MonoBehaviour{
    GameObject Attackflag;
    public BoxCollider2D col;

    public GameObject Storn0;
    public GameObject Storn1;
    public GameObject Storn2;
    
    AudioSource audioSource; 
    public AudioClip break1;
    public AudioClip break2;

    public bool Stornbreak;
    public int StornChange;

    public float StornTime;
    float StornBreakTimer = 0.1f;
    float StornChangeTimer = 1.0f;

    // Start is called before the first frame update
    public void Start(){
        Attackflag = GameObject.Find("player");
        Stornbreak = false;
        StornChange = 0;

        StornTime = 0f;

        Storn0.SetActive(true);
        Storn1.SetActive(false);
        Storn2.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }

    public void Update(){
        StornTime += Time.deltaTime;

        //画像切り替え
        if(Stornbreak == true){
            if(StornChange == 0){
                Storn1Change();
            }
            else if(StornChange == 1){
                Storn2Change();
            }
        }

        //画像非表示
        if(StornTime >= StornChangeTimer){
            if(StornChange == 1){
                Storn0.SetActive(false);
            }
            else if(StornChange == 2){
                Storn1.SetActive(false);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision){
        if(StornTime >= StornChangeTimer){
            if (collision.gameObject.tag == "Player" && Attackflag.GetComponent<Player>().attackflag == true){
                Stornbreak = true;

                if(Stornbreak == true){
                    //音の管理
                    if(StornChange == 0 || StornChange == 1){
                        StornTime = 0f;
                        audioSource.PlayOneShot(break1);
                        Debug.Log("audio01");
                    }
                    else if(StornChange == 2){
                        audioSource.PlayOneShot(break2);
                        col.enabled = false;
                        Debug.Log("audio02");
                    }
                }
            }
        }
    }

    void Storn1Change(){
        Storn1.SetActive(true);
        StornChange = 1;
        Debug.Log("01");
    }

    void Storn2Change(){
        Storn2.SetActive(true);
        StornChange = 2;
        Debug.Log("02");
    }
}