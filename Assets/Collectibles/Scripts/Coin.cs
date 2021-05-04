using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectible
{
    [SerializeField] [Range(0,360)] float rotateSpeed;
    public override void OnPlayerEntered(Collision collision)
    {
        Debug.Log("Player has hit a coin!");
        Destroy(gameObject);
    }
    private void Update()
    {
        //Vector3 currentRotation = transform.rotation.eulerAngles;
        transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
    }
}
