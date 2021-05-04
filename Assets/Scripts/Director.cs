using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    public static Director Instance;
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
    public void GainCoin(int amt)
    {
        playerInventory.GainCoin(amt);
    }
}
