using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemScript : MonoBehaviour
{
    GameObject Attack;
    Attack attack;

    public float iTime;
    public float timer = 0.5f;
    public float jTime;

    public bool iflag = false;

    void Start(){
        Attack = GameObject.Find("player");
        attack = Attack.GetComponent<Attack>();

        gameObject.SetActive(false);
    }

    void FixedUpdate (){
        iTime += Time.deltaTime;
        if(iflag == true && jTime <= 3f){
            jTime += Time.deltaTime;
        }
        else if(iflag == true && jTime > 3f){
            iflag = false; 
        }
        
        //item処理
        for(;attack.HPflag == true;){
            iTime = 0f;
            attack.HPflag = false;
            gameObject.SetActive(true);
        }
    }

    public void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player" && timer <= iTime){
            Debug.Log("unti");
            gameObject.SetActive(false);
        }
    }
}
