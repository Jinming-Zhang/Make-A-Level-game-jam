using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectible
{
    [SerializeField] [Range(0,360)] float rotateSpeed;

    private void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
    }

    protected override void OnItemCollected()
    {
        base.OnItemCollected();
        Debug.Log("Player collected a coin");
    }
}
