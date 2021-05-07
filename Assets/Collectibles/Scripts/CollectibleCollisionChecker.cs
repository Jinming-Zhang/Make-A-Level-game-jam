using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CollectibleCollisionChecker : MonoBehaviour
{
    [SerializeField] Collectible collectible;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GetComponent<Collider>().enabled = false;
            collectible.OnPlayerEnteredCollectible(other);
        }
    }
}
