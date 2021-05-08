using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI text;
    [HideInInspector]
    public int score;
    [Button("RESET")]
    public void Reset()
    {
        PlayerPrefs.DeleteKey("high score");
    }


    public void AddPoint(int amount)
    {
        score += amount;
        if(score > PlayerPrefs.GetInt("high score"))
        {
            Debug.Log("set");
            PlayerPrefs.SetInt("high score", score);
        }
        text.text = "score: " + score;
    }
    public void RemovePoint(int amount)
    {
        score -= amount;
        text.text = "score: " + score;
    }
}
