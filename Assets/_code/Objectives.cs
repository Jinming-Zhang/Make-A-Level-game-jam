using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Objectives : MonoBehaviour
{
    public List<GameObject> objectives;
    public float viewTime;
    CameraFollowV2 cfv;
    [Button("test")] // Specify button text
    public void MethodTwo() 
    {
        StartCoroutine(view(objectives[0].transform));
    }
    // Start is called before the first frame update
    void Start()
    {
        cfv = GetComponent<CameraFollowV2>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator view(Transform input)
    {
        cfv.targets.Add(input);
        yield return new WaitForSeconds(viewTime);
        cfv.targets.Remove(input);
    }
}
