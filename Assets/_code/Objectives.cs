using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Objectives : MonoBehaviour
{
    public List<GameObject> objectives;
    public float viewTime;
    public float aditionalWait;
    CameraFollowV2 cfv;
    private bool done;
    private bool objectiveDone;
    [Button("test")] // Specify button text
    public void MethodTwo() 
    {
        StartCoroutine(DoPhase(0));
    }
    // Start is called before the first frame update
    void Start()
    {
        cfv = GetComponent<CameraFollowV2>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            Debug.Log("start timer");
            done = false;
        }
    }
    private IEnumerator DoPhase(int index)
    {
        GameObject _phase = objectives[index];
        StartCoroutine(view(_phase.transform));
        _phase.GetComponent<FixScript>();
        yield return new WaitForSeconds(viewTime + aditionalWait);
        done = true;
    }
    private IEnumerator view(Transform input)
    {
        cfv.targets.Add(input);
        yield return new WaitForSeconds(viewTime);
        cfv.targets.Remove(input);

    }
}
