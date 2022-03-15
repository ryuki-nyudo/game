using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nocback : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine("dmgFalse");
        }
    }
}
