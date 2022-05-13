using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Return : MonoBehaviour
{
    private int minute;
    private float second;
    private int count;

    private int pause;
    private int MenuSelect = 0;

    [SerializeField] GameObject PausePanel;
    GameObject GameOver;

    float gameovertime;
    float Timer = 2.0f;
    bool TimeStart;

    // Start is called before the first frame update
    void Start()
    {
        gameovertime = 0.0f;
        GameOver = GameObject.Find("player");
        TimeStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOver.GetComponent<PlayerHPBar>().gameoverflag == true){
            if(TimeStart == false){
                TimeStart = true;
                gameovertime = 0.0f;
            }
            gameovertime += Time.unscaledDeltaTime;
            if(gameovertime >= Timer){
                Debug.Log("unti");
                PauseCommand();
            }
        }
    }

    void PauseCommand()
    {
        PausePanel.SetActive(true);
    }

}
