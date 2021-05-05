using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : Collectible
{
    protected override void OnItemCollected()
    {
        base.OnItemCollected();
        Debug.Log($"Player collcted a gear, player has {Director.Instance.CheckItem(this.itemType)} gears now!");
        Destroy(transform.parent.gameObject);
    }
}
