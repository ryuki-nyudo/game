using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goalitem : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip GoalSE;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(GoalSE);
            Invoke("SceneChange", 1.5f);
        }
    }
    void SceneChange()
    {
        SceneManager.LoadScene("Game2");
    }
}