using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    public enum CollectibleItem
    {
        Coin,
        Gear
    }

    public int CoinOwned = 0;
    public int GearOwned = 0;
    public void GainItem(CollectibleItem itemType, int amt)
    {
        switch(itemType)
        {
            case CollectibleItem.Coin:
                GainCoin(amt);
                break;
            case CollectibleItem.Gear:
                GainGear(amt);
                break;
            default:
                break;
        }
    }

    private void GainCoin(int amt)
    {
        CoinOwned = Mathf.Max(0, CoinOwned + amt);
        UpdateUI();
    }

    private void GainGear(int amt)
    {
        GearOwned = Mathf.Max(0, GearOwned + amt);
        UpdateUI();
    }

    public void UpdateUI()
    {
        Debug.Log("Hud ui not connected yet");
    }
}
