using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    public enum CollectibleItem
    {
        Gear,
        Medkit
    }

    private Dictionary<CollectibleItem, int> Inventory = new Dictionary<CollectibleItem, int>();
    public void GainItem(CollectibleItem itemType, int amt)
    {
        if(Inventory.ContainsKey(itemType))
        {
            Inventory[itemType] = Mathf.Max(0, Inventory[itemType] + amt);
            UpdateUI();
        }
        else
        {
            Inventory.Add(itemType, 1);
        }
        UpdateUI();
    }

    public int CheckItem(CollectibleItem itemType)
    {
        if(Inventory.ContainsKey(itemType))
        {
            return Inventory[itemType];
        }
        else
        {
            return 0;
        }
    }

    public void UpdateUI()
    {
        Debug.Log("Hud ui not connected yet");
    }
}
