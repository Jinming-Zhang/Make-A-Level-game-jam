using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NaughtyAttributes;


public class FixScript : MonoBehaviour
{
    public bool isActivated;
    public GameObject screen;
    public float radius;
    [Layer]
    public int playerLayer;
    Objectives _objectives;
    public void Activate(Objectives input)
    {
        _objectives = input;
        isActivated = true;
        screen.SetActive(true);
    }
    public void Deactivate(Objectives input)
    {
        _objectives = input;
        isActivated = false;
        screen.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isActivated)
        {
            if (collision.gameObject.layer == playerLayer)
            {
                isActivated = false;
                _objectives.EndPhase();
                screen.SetActive(false);
            }
        }
    }
}
