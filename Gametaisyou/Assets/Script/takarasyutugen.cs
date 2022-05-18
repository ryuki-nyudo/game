using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takarasyutugen : MonoBehaviour
{

    GameObject Bos;
    BosHPBar bos;

    public GameObject takara;
 
    void Start()
    {
        Bos = GameObject.Find("player");
        bos = Bos.GetComponent<BosHPBar>();

        takara.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (bos.currentHp <= 0)
        {
            takara.gameObject.SetActive(true);
        }
    }

    
}
