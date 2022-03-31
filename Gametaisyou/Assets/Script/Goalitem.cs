using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goalitem : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip GoalSE;

    public GameObject falseGoal;
    public GameObject trueGoal;

    GameObject Player;
    void Start(){
        audioSource = GetComponent<AudioSource>();
        Player = GameObject.Find("player");
    }

    void Update(){
        if(Player.GetComponent<Player>().goalitem == false){
            falseGoal.SetActive(true);
            trueGoal.SetActive(false);
        }
        else if(Player.GetComponent<Player>().goalitem == true){
            falseGoal.SetActive(false);
            trueGoal.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Player.GetComponent<Player>().goalitem == true)
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