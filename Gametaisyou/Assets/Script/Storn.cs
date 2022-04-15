using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Storn : MonoBehaviour{
    GameObject Player;
    public GameObject Storn0;
    public GameObject Storn1;
    public GameObject Storn2;

    public bool Stornbreak;
    public BoxCollider2D col;
    // Start is called before the first frame update
    void Start(){
        Player = GameObject.Find("player");
        Stornbreak = false;

        Storn0.SetActive(true);
        Storn1.SetActive(false);
        Storn2.SetActive(false);
    }

    // Update is called once per frame
    void Update(){

    }

    public void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player" && Player.GetComponent<Player>().attackflag == true){
            Stornbreak = true;
            if(Stornbreak == true){
                if(Storn0.activeSelf == true){
                    Debug.Log("0");
                    Storn0.SetActive(false);
                    Stornbreak = false;
                    Storn0Change();
                }
                else if(Storn1.activeSelf == true){
                    Debug.Log("1");
                    Storn1.SetActive(false);
                    Stornbreak = false;
                    Storn1Change();
                }
                else if(Storn2.activeSelf == true){
                    Debug.Log("2");
                    Storn2.SetActive(false);
                    Stornbreak = false;
                    col.enabled = false;
                }
            }
        }
    }

    public void Storn0Change(){
        Storn1.SetActive(true);
        Storn1.transform.position = Storn0.transform.position;
    }

    public void Storn1Change(){
        Storn2.SetActive(true);
        Storn2.transform.position = Storn0.transform.position;
    }
}
