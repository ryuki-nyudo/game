using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StornChangeScript : MonoBehaviour
{

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

    public float Storntime;
    public float StornTimer = 2.0f;

    // Start is called before the first frame update
    public void Start()
    {
        Attackflag = GameObject.Find("player");
        Stornbreak = false;
        StornChange = 0;
        Storntime = 0f;

        Storn0.SetActive(true);
        Storn1.SetActive(false);
        Storn2.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }

    public void Update(){
        Storntime += Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && Attackflag.GetComponent<Player>().attackflag == true)
        {
            Stornbreak = true;
            //処理を遅らせる
            if(Storntime >= StornTimer){
                if(Stornbreak == true){
                    if(StornChange == 0){
                        Stornbreak = false;
                        audioSource.PlayOneShot(break1);
                        Storn1Change();
                        Storntime = 0f;
                    }
                    else if(StornChange == 1){
                        Stornbreak = false;
                        audioSource.PlayOneShot(break1);
                        Storn2Change();
                        Storntime = 0f;
                    }
                    else if(StornChange == 2){
                        Stornbreak = false;
                        audioSource.PlayOneShot(break2);
                        col.enabled = false;　//コライダーを消す
                        StornChange = 0;
                        Storntime = 0f;
                    }
                }
            }
        }
    }

    public void Storn1Change(){
        Debug.Log("01");
        Storn1.SetActive(true);
        StornChange = 1;
    }

    public void Storn2Change(){
        Debug.Log("02");
        Storn2.SetActive(true);
        StornChange = 2;
    }
}