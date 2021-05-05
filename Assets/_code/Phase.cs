using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
[System.Serializable]
public class Phase
{
    public bool isWait;
    [ShowIf("isWait")]
    [AllowNesting]
    public float time;
    [HideIf("isWait")]
    [AllowNesting]
    public GameObject Objective;
}
