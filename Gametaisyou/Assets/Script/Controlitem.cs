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
        DeltaTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        DeltaTimer += Time.deltaTime;

        if (DeltaTimer > Loop_Speed)
        {
            transform.position += new Vector3(0, -down_length, 0);
            DeltaTimer = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D Coll)
    {
        Destroy(gameObject);
    }
}
