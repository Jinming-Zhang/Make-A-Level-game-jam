using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Animator transition;
    public float transTime;
    [Scene]
    public int Scene;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void PlayGame()
    {
        StartCoroutine(LoadLevel(Scene));
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }
    
    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        if (audioManager != null)
        {
            audioManager.Stop("air");
            audioManager.Stop("mayday");
            audioManager.Stop("correct");
            audioManager.Stop("wrong");
            audioManager.Stop("laser");
            audioManager.Stop("meteore");
        }
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int indexBuild)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(indexBuild);
    }
    
}
