using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    }

    public void UpdateCoin(int amt)
    {
        coinText.text = $"Coins: {amt}";
    }
}
