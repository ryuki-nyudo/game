using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    private int minute;
    private float second;
    private int count;

    private int pause;
    private int MenuSelect = 0;

    [SerializeField] GameObject PausePanel;


    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PauseCommand();
    }

    void PauseCommand()
    {
        {
                if (Input.GetKeyDown("joystick button 7"))
                {
                    if (pause == 0)
                    {
                        PausePanel.SetActive(true);
                        pause = 1;

                        Time.timeScale = 0f;
                    }
                    else
                    {
                        PausePanel.SetActive(false);
                        pause = 0;
                        Time.timeScale = 1f;
                    }
                }
                else
                {
                    ;
                }
        }
    }
}
