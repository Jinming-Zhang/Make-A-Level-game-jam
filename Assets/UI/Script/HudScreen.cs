using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HudScreen : MonoBehaviour
{
    public static HudScreen Instance;
    [SerializeField] TextMeshProUGUI coinText;

    private void Awake()
    {
        if(Instance && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        InitializeUIComponents();
    }

    private void InitializeUIComponents()
    {
        coinText.text = $"Coins: {0}";
    }

    public void UpdateCoin(int amt)
    {
        coinText.text = $"Coins: {amt}";
    }
}
