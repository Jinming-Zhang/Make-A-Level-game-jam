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
    float time;
    public void Activate(Objectives input, float deactivateTime)
    {
        _objectives = input;
        isActivated = true;
        time = deactivateTime;
        screen.SetActive(true);
    }
    public void Deactivate(Objectives input)
    {
        _objectives = input;
        isActivated = false;
        screen.SetActive(false);
    }
    public void onFix(InputAction.CallbackContext value)
    {
        if(isActivated)
        {
            if (value.time > time)
            {
                if(Check())
                {
                    isActivated = false;
                    _objectives.EndPhase();
                    screen.SetActive(false);
                }
            }
        }
    }
    private bool Check()
    {
        Collider[] _colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in _colliders)
        {
            if (nearbyObject.gameObject.layer == playerLayer)
            {
                return true;
            }
        }
        return false;
    }
}
