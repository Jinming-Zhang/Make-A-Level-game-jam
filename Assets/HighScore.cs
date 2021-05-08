using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI text;
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
