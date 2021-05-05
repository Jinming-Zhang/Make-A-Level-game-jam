using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Collectible : MonoBehaviour
{
    [SerializeField] protected PlayerInventory.CollectibleItem itemType;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Director.Instance.GainItem(itemType, 1);
            OnItemCollected();
            Destroy(gameObject);
        }
    }

    protected virtual void OnItemCollected()
    {
    }
}
