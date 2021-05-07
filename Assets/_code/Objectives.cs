using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using NaughtyAttributes;

public class Objectives : MonoBehaviour
{
    public TargetIndicator indicator;
    public Transform player;
    public List<GameObject> objectives;
    public float viewTime;
    [Label("Extra Seconds Per Meter")]
    public float secondsPerMeter;
    public float MinTime;
    public float PressTime;
    public UnityEvent ObjectiveLostEvent;
    CameraFollowV2 cfv;
    private bool objectiveDone;
    private int ObjectIndex;
    private float distanceWithTime;
    private int last;
    private float time;
    GameObject _phase;
    AudioManager audioManager;
    public Countdown countDown;
    public ScoreCounter scoreCounter;
    [Button("Next")] // Specify button text
    public void Button()
    {
        EndPhase();
    }
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        cfv = GetComponent<CameraFollowV2>();
        objectiveDone = false;
        StartCoroutine(DoPhase(GenerateIndex()));
        if (ObjectiveLostEvent == null)
            ObjectiveLostEvent = new UnityEvent();    }
    private IEnumerator DoPhase(int index)
    {
        _phase = objectives[index];
        _phase.GetComponent<FixScript>().Activate(this, PressTime);
        StartCoroutine(view(_phase.transform));
        StartCoroutine(Timer(GetDistance(_phase)));
        yield return new WaitForSeconds(viewTime / 2);
        audioManager.Play("mayday");
    }
    public void EndPhase()
    {
        objectiveDone = true;
        Check();
    }
    private IEnumerator view(Transform input)
    {
        indicator.Target = null;
        cfv.targets.Add(input);
        yield return new WaitForSeconds(viewTime);
        cfv.targets.Remove(input);
        indicator.Target = input;
    }

    private IEnumerator Timer(float time)
    {
        countDown.StartTimer(time);
        yield return new WaitForSeconds(time);
        Check();
    }
    private void Check()
    {
        //StopCoroutine(Timer(time));
        StopAllCoroutines();
        if (objectiveDone)
        {
            _phase.GetComponent<FixScript>().Deactivate(this);
            scoreCounter.AddPoint(1);
            ObjectIndex = GenerateIndex();
            if (objectives.Count - 1 >= ObjectIndex)
                StartCoroutine(DoPhase(ObjectIndex));
            else
                Debug.LogWarning("ou of range or smg");
            objectiveDone = false;
        }
        else
        {
            _phase.GetComponent<FixScript>().Deactivate(this);
            scoreCounter.RemovePoint(1);
            ObjectiveLostEvent.Invoke();
            ObjectIndex = GenerateIndex();
            if (objectives.Count - 1 >= ObjectIndex)
                StartCoroutine(DoPhase(ObjectIndex));
            else
                Debug.LogWarning("out of range or smg");
            objectiveDone = false;
        }
    }
    private int GenerateIndex()
    {
        int random = last;
        random = Random.Range(0, objectives.Count);
        while (random == last)
        {
            random = Random.Range(0, objectives.Count);

        }
        last = random;
        return random;
    }
    private float GetDistance(GameObject _objective)
    {
        distanceWithTime = Vector3.Distance(_objective.transform.position, player.position) * secondsPerMeter;
        distanceWithTime += MinTime;
        time = distanceWithTime;
        return distanceWithTime;
    }

}
