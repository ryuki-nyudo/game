using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemScript : MonoBehaviour
{
    GameObject Attack;
    Attack attack;

    public float iTime;
    public float timer = 0.5f;
    public float jTime;

    public bool iflag = false;

    public GameObject Box;
    public GameObject item;
    public bool ixflag;

    BoxDestroy script;
    GameObject woodbox;

    void Start(){
        Attack = GameObject.Find("player");
        attack = Attack.GetComponent<Attack>();

        item.gameObject.SetActive(false);
        //Box.gameObject.SetActive(true);
        ixflag = true;

        woodbox = GameObject.FindWithTag("itembox");
        script = woodbox.GetComponent<BoxDestroy>();

            }

    //    void Update(){
    //        //item処理
    //        if (Box.activeSelf == false && ixflag == true)
    //        {
    //            iTime = 0f;
    //            ixflag = false;
    //            attack.HPflag = false;
    //            item.gameObject.SetActive(true);
    //        }
    //    }
    //}
    void OnCollisionEnter2D(Collision2D collision) {
        //item処理
        if (collision.gameObject.tag == "Player") {
            if (script.KAIsyutugen == true && ixflag == true)
            {

                iTime = 0f;
                ixflag = false;
                attack.HPflag = false;
                item.gameObject.SetActive(true);
            }
        }
    }
}