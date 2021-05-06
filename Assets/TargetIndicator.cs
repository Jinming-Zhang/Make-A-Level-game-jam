using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public Transform Target;
    [SerializeField] private GameObject arrow;

    private void Update()
    {
        if(Target != null)
        {
            arrow.SetActive(true);
            Vector3 _target = new Vector3(Target.position.x, Target.position.y, transform.position.z);
            var dir = _target - transform.position;

            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            arrow.SetActive(false);
        }
    }
}
