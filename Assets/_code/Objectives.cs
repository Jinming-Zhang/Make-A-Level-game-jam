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
            Debug.Log("done");
            done = false;
        }
    }
    private IEnumerator DoPhase(int index)
    {
        Phase _phase = objectives[index];
        if (_phase.isWait == false)
        {
            StartCoroutine(view(_phase.Objective.transform));
            _phase.Objective.GetComponent<FixScript>();
        }
        else
        {
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
