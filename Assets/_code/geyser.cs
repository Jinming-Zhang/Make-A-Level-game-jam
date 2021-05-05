using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class geyser : MonoBehaviour
{
    public Transform from;
    public Transform to;
    public GameObject air;
    public float force;
    [Layer]
    public int playerLayer;


    // Update is called once per frame
    void Update()
    {
        from.LookAt(to.position);
        float distance = Vector3.Distance(from.position, to.position);
        air.transform.localScale = new Vector3(1, 1, distance/2);
        if(Physics.Raycast(from.position, from.forward, out RaycastHit hit, distance))
        {
            if(hit.transform.gameObject.layer ==playerLayer)
            {
                Rigidbody rb = hit.transform.gameObject.GetComponent<Rigidbody>();
                rb.AddExplosionForce(force, from.position, distance);
            }
        }
    }
}
