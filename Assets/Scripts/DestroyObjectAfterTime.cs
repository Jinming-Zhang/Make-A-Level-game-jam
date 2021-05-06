using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectAfterTime : MonoBehaviour
{
    public float timeToDestroy=3f;
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

}
