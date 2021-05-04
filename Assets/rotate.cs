using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float speed;
    public bool reversed;
    private float rotZ;
    void Update()
    {
        if(reversed)
        {
            rotZ += Time.deltaTime * speed;
        }
        else
        {
            rotZ += -Time.deltaTime * speed;
        }
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
