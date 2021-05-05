using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Objectives : MonoBehaviour
{
    public List<Phase> objectives;
    public float viewTime;
    CameraFollowV2 cfv;
    private bool done;
    [Button("test")] // Specify button text
    public void MethodTwo() 
    {
        StartCoroutine(DoPhase(0));
        if (done)
        {
            Debug.Log("done");
        }
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
    private IEnumerator DoPhase(int index)
    {
        Phase _phase = objectives[index];
        if (_phase.isWait == false)
        {
            StartCoroutine(view(_phase.Objective.transform));
            done = true;
        }
        else
        {
            Debug.Log(_phase.time);
            yield return new WaitForSeconds(_phase.time);
            done = true;
        }
    }
    private IEnumerator view(Transform input)
    {
        cfv.targets.Add(input);
        yield return new WaitForSeconds(viewTime);
        cfv.targets.Remove(input);

    }
}
