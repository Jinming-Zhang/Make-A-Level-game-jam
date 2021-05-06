using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenuSettings : MonoBehaviour
{

    Resolution[] resolutionsArray; 
    public TMP_Dropdown resolutionDropdown;

    void Start()
    {
        

        resolutionsArray = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResoutionIndex = 0;
        for(int i=0; i<resolutionsArray.Length;i++)
        {
            string option = resolutionsArray[i].width + " x " + resolutionsArray[i].height;
            options.Add(option);

            if(resolutionsArray[i].width == Screen.currentResolution.width &&
                resolutionsArray[i].height == Screen.currentResolution.height)
            {
                currentResoutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResoutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void SetFullScreen(bool fullscreenBool)
    {
        Screen.fullScreen = fullscreenBool;    
    }


    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutionsArray[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
    }
}
