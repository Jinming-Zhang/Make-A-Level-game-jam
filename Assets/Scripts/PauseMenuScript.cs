using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PauseMenuScript : MonoBehaviour
{
    private static bool GameIsPause = false;
    public GameObject pauseMenuUI;
    public PlayerController playerController;
   

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
      
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void Pause()
    {
       
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void SetNormalControls(bool normal)
    {
        playerController.IsInverted = normal;
    }

}
