using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    [SerializeField] protected PlayerInventory.CollectibleItem itemType;

    public void OnPlayerEnteredCollectible(Collider player)
    {
        Director.Instance.GainItem(itemType, 1);
        OnItemCollected();
    }
    protected virtual void OnItemCollected()
    {
        Destroy(gameObject);
    }
}
