using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class geyser : MonoBehaviour
{
    public Transform from;
    public Transform to;
    public float force;
    [Layer]
    public int playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        from.LookAt(to.position);
        Debug.DrawRay(from.position, from.forward, Color.green);
        if(Physics.Raycast(from.position, from.forward, out RaycastHit hit, Vector3.Distance(from.position, to.position)))
        {
            if(hit.transform.gameObject.layer ==playerLayer)
            {
                Debug.Log(hit);
                Rigidbody rb = hit.transform.gameObject.GetComponent<Rigidbody>();
                rb.AddExplosionForce(force, from.position, Vector3.Distance(from.position, to.position));
            }
        }
    }
}
