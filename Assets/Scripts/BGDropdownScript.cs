using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BGDropdownScript : MonoBehaviour
{
    private int currentBG;
    public Button leftArrow;
    public Button rightArrow;
    
    public TextMeshProUGUI textToChange;
 

    private void Awake()
    {
        SelectBackground(0);
        
    }

    private void SelectBackground(int _index)
    {
        leftArrow.interactable = (_index != 0);
        rightArrow.interactable = (_index != transform.childCount -1);

        for(int i = 0;i<transform.childCount;i++)
        {
            //transform.GetChild(i).gameObject.SetActive(i == _index);


            if (i == _index)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                textToChange.SetText(transform.GetChild(i).gameObject.name); 
                
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        

    }

    public void ChangeBackground(int _change)
    {
        currentBG += _change;
        SelectBackground(currentBG);
        
    }
}
