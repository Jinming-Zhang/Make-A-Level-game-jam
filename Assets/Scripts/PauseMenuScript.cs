using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenuScript : MonoBehaviour
{
    private static bool GameIsPause = false;
    public GameObject pauseMenuUI;
   // public GameObject player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
      //  player.GetComponent<RigidbodyCharacterController>().enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void Pause()
    {
       // player.GetComponent<RigidbodyCharacterController>().enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
   
}
