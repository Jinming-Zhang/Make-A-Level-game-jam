using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class Countdown : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Volume volume;
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

                float value = Mathf.InverseLerp(startTime, time, Time.time) / 3;
                LensDistortion lensDistortion;
                if(volume.profile.TryGet<LensDistortion>(out lensDistortion))
                {
                    lensDistortion.intensity.value = value;
                }
                ChromaticAberration aberration;
                if (volume.profile.TryGet<ChromaticAberration>(out aberration))
                {
                    aberration.intensity.value = value;
                }
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
