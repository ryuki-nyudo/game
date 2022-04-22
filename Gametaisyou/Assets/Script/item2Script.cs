using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item2Script : MonoBehaviour
{
    public float iTime;
    public float timer = 0.5f;
    public float jTime;

    public bool iflag = false;
    
    void FixedUpdate (){
        iTime += Time.deltaTime;
        if(iflag == true && jTime <= 3f){
            jTime += Time.deltaTime;
        }
        else if(iflag == true && jTime > 3f){
            iflag = false; 
        }
    }
}
