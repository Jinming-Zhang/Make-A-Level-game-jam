using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : Collectible
{
    [SerializeField] Animator animator;
    protected override void OnItemCollected()
    {
        animator.SetTrigger("Collected");
        Debug.Log($"Player collcted a gear, player has {Director.Instance.CheckItem(this.itemType)} gears now!");
        StartCoroutine(WaitForCollectedAnimationCR());
    }

    IEnumerator WaitForCollectedAnimationCR()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
