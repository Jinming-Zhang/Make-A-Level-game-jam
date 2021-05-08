using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : Collectible
{
	[SerializeField] Animator animator;
	public float HealAmount = 1;

	protected override void OnItemCollected()
	{
		animator.SetTrigger("Collected");
		Debug.Log($"Player collcted a medkit, player has {Director.Instance.CheckItem(this.itemType)} medkits now!");
		StartCoroutine(WaitForCollectedAnimationCR());
	}

	IEnumerator WaitForCollectedAnimationCR()
	{
		yield return new WaitForSeconds(.5f);
		Destroy(gameObject);
	}

}
