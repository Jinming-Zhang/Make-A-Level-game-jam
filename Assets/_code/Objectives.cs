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
    private int ObjectIndex;
    [Button("test")] // Specify button text
    public void MethodTwo() 
    {
        StartCoroutine(DoPhase(0));
    }
    // Start is called before the first frame update
    void Start()
    {
        cfv = GetComponent<CameraFollowV2>();
        StartCoroutine(DoPhase(ObjectIndex));
    }

    // Update is called once per frame
    void Update()
    {
        if (objectiveDone)
        {
            ObjectIndex++;
            Debug.Log("Fixed it");
            if(objectives.Count-1 > ObjectIndex)
                StartCoroutine(DoPhase(ObjectIndex));
            objectiveDone = false;
        }
    }
    private IEnumerator DoPhase(int index)
    {
        GameObject _phase = objectives[index];
        StartCoroutine(view(_phase.transform));
        _phase.GetComponent<FixScript>().Activate(this);
        yield return new WaitForSeconds(1);
    }
    public void EndPhase()
    {
        objectiveDone = true;
    }
    private IEnumerator view(Transform input)
    {
        cfv.targets.Add(input);
        yield return new WaitForSeconds(viewTime);
        cfv.targets.Remove(input);
    }

}
