using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
	public static Director Instance;
	[SerializeField] Health playerHealth;
	public Health PlayerHealth
	{
		get
		{
			if (playerHealth)
			{
				return playerHealth;
			}
			else
			{
				Health h = FindObjectOfType<Health>();
				if (h)
				{
					return h;
				}
				else
				{
					Debug.LogError("Can not find Health component in the game");
					return null;
				}
			}
		}
	}
	private PlayerInventory playerInventory = new PlayerInventory();
	private void Awake()
	{
		if (Instance && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
			DontDestroyOnLoad(this);
		}
	}

	public void GainItem(PlayerInventory.CollectibleItem itemType, Collectible collecible)
	{
		playerInventory.GainItem(itemType, collecible);
	}

	public int CheckItem(PlayerInventory.CollectibleItem itemType)
	{
		return playerInventory.CheckItem(itemType);
	}
}
