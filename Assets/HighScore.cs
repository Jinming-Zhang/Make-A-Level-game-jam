using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;


public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI text;
    [Button("RESET")]
    public void Reset()
    {
        PlayerPrefs.DeleteKey("high score");
    }
    void Start()
    {
        int score = PlayerPrefs.GetInt("high score");
        if(score == null)
        {
            PlayerPrefs.SetInt("high score", 0);
            score = 0;
        }
        text.text = "High score: " + score;
    }
}
