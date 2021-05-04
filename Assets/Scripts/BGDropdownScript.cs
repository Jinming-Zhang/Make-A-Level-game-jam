using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGDropdownScript : MonoBehaviour
{
    private int currentBG;
    public Button leftArrow;
    public Button rightArrow;

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
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }

    public void ChangeBackground(int _change)
    {
        currentBG += _change;
        SelectBackground(currentBG);
    }
}
