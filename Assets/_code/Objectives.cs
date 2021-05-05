using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using NaughtyAttributes;

public class Objectives : MonoBehaviour
{
    public List<GameObject> objectives;
    public float viewTime;
    [Label("Extra Seconds Per Meter")]
    public float secondsPerMeter;
    public UnityEvent ObjectiveLostEvent;
    CameraFollowV2 cfv;
    private bool objectiveDone;
    private int ObjectIndex;
    private float distanceWithTime;
    void Start()
    {
        cfv = GetComponent<CameraFollowV2>();
        objectiveDone = false;
        StartCoroutine(DoPhase(GenerateIndex()));
        if (ObjectiveLostEvent == null)
            ObjectiveLostEvent = new UnityEvent();
    }
    private IEnumerator DoPhase(int index)
    {
        GameObject _phase = objectives[index];
        _phase.GetComponent<FixScript>().Activate(this);
        StartCoroutine(view(_phase.transform));
        StartCoroutine(Timer(GetDistance(_phase)));
        yield return new WaitForSeconds(1);
    }
    public void EndPhase()
    {
        objectiveDone = true;
        Check();
    }
    private IEnumerator view(Transform input)
    {
        cfv.targets.Add(input);
        yield return new WaitForSeconds(viewTime);
        cfv.targets.Remove(input);
    }

    private IEnumerator Timer(float time)
    {
        Debug.Log("Starting the timer! (" + time + ")");
        yield return new WaitForSeconds(time);
        Check();
    }
    private void Check()
    {
        StopAllCoroutines();
        if (objectiveDone)
        {
            ObjectIndex = GenerateIndex();
            Debug.Log("Fixed it");
            if (objectives.Count - 1 >= ObjectIndex)
                StartCoroutine(DoPhase(ObjectIndex));
            else
                Debug.LogWarning("ou of range or smg");
            objectiveDone = false;
        }
        else
        {
            ObjectiveLostEvent.Invoke();
            ObjectIndex = GenerateIndex();
            Debug.LogWarning("lost it");
            if (objectives.Count - 1 >= ObjectIndex)
                StartCoroutine(DoPhase(ObjectIndex));
            else
                Debug.LogWarning("out of range or smg");
            objectiveDone = false;
        }
    }
    private int GenerateIndex()
    {
        return Random.Range(0, objectives.Count);
    }
    private float GetDistance(GameObject _objective)
    {
        distanceWithTime = Vector3.Distance(_objective.transform.position, transform.position) * secondsPerMeter;
        return distanceWithTime;
    }

}
