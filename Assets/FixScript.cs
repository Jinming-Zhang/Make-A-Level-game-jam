using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixScript : MonoBehaviour
{
    public bool isActivated;
    Objectives _objectives;
    public void Acticave(Objectives input)
    {
        _objectives = input;
        isActivated = true;
    }
    private void Update()
    {
        
    }
}
