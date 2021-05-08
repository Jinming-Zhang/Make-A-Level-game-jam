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
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int indexBuild)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(indexBuild);
    }
    
}
