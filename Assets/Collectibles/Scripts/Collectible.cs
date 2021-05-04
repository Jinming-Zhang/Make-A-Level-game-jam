using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Collectible : MonoBehaviour
{
    public abstract void OnPlayerEntered(Collision collision);
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            OnPlayerEntered(collision);
        }
    }
}
