using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    public static Director Instance;
    public Health playerHealth;
    private PlayerInventory playerInventory = new PlayerInventory();
    private void Awake()
    {
        if(Instance && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void GainItem(PlayerInventory.CollectibleItem itemType, int amt)
    {
        playerInventory.GainItem(itemType, amt);
    }

    public int CheckItem(PlayerInventory.CollectibleItem itemType)
    {
        return playerInventory.CheckItem(itemType);
    }
}
