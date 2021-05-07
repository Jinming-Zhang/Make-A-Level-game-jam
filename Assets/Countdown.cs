using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI text;
    float startTime;
    bool display;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(display)
        {
            if(Time.time - startTime < time)
            {
                float up = Time.time - startTime;
                float endTime = time - up;
                text.text = Mathf.RoundToInt(endTime).ToString();
            }
            else
            {
                display = false;
            }
        }
    }
    public void StartTimer(float amount)
    {
        startTime = Time.time;
        display = true;
        time = amount;
    }
}
