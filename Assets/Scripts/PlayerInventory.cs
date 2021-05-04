using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    public int CoinOwned = 0;

    public void GainCoin(int amt)
    {
        CoinOwned = Mathf.Max(0, CoinOwned + amt);
        UpdateUI();
    }
    public void UpdateUI()
    {
        HudScreen.Instance.UpdateCoin(CoinOwned);
    }
}
