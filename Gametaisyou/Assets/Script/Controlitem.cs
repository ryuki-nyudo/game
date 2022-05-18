using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlitem : MonoBehaviour
{

    public float Loop_Speed;
    public float down_length;
    private float DeltaTimer;

   

    

    // Use this for initialization
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y >= -6.9)
        {
            transform.position += new Vector3(0, -down_length, 0);   
        }

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            Destroy(gameObject);
        }
    }
}
