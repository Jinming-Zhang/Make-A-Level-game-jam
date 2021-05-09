using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGRotationScript : MonoBehaviour
{
    private float YRotation;
    public float speed;

    void Update()
    {
        YRotation += speed;
        // transform.Rotate(Vector3.up * Time.deltaTime * speed);
        transform.rotation = Quaternion.Euler(-63, YRotation, 0);
    }
}
