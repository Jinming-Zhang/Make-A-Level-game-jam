using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class SetSlider : MonoBehaviour
{
    public Slider slider;
    [Button("RESET")]
    public void Reset()
    {
        PlayerPrefs.DeleteKey("loudness");
    }
    // Start is called before the first frame update
    void Awake()
    {
        float value = PlayerPrefs.GetFloat("loudness");
        if (value == 0)
        {
            value = -5;
            PlayerPrefs.SetFloat("loudness", value);
        }
        Debug.Log(value);
        slider.value = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
