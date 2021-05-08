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

	private Dictionary<CollectibleItem, List<Collectible>> Inventory = new Dictionary<CollectibleItem, List<Collectible>>();
	public void GainItem(CollectibleItem itemType, Collectible collectible)
	{
		if (Inventory.ContainsKey(itemType))
		{
			Inventory[itemType].Add(collectible);
			UpdateUI();
		}
		else
		{
			Inventory.Add(itemType, new List<Collectible>());
            Inventory[itemType].Add(collectible);
		}
		if (Inventory.ContainsKey(CollectibleItem.Medkit))
		{
            List<Collectible> medkits = Inventory[CollectibleItem.Medkit];
			while (medkits.Count > 0)
			{
                Medkit medkit = medkits[0] as Medkit;
				Director.Instance.PlayerHealth.HealthSync += medkit.HealAmount;
				medkits.Remove(medkit);
			}
		}
		UpdateUI();
	}

	public int CheckItem(CollectibleItem itemType)
	{
		if (Inventory.ContainsKey(itemType))
		{
			return Inventory[itemType].Count;
		}
		else
		{
			return 0;
		}
	}

	public void UpdateUI()
	{
	}
}
