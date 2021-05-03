using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Animator transition;
    public float transTime;

    public void PlayGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
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
