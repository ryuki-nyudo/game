using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDownTime : MonoBehaviour{
    GameObject EnemyMove;
    float EnemyDownTimer = 2.0f;
    float EnemyCount;
    void Start(){
        EnemyMove = GameObject.Find("ika_0");
        EnemyCount = 0.0f;
    }

    // Update is called once per frame
    void Update(){
        EnemyCount += Time.deltaTime;
        if(EnemyCount >= EnemyDownTimer && EnemyMove.GetComponent<EnemyDown>().Enemyflag == true){
            gameObject.SetActive(false);
        }
    }
}
