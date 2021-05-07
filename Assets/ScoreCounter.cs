using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI text;
    [HideInInspector]
    public int score;

    public void AddPoint(int amount)
    {
        score += amount;
        text.text = "score: " + score;
    }
    public void RemovePoint(int amount)
    {
        score -= amount;
        text.text = "score: " + score;
    }
}
