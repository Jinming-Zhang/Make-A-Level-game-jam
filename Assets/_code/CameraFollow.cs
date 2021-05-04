
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    
    [Range(0,10)]
    public float smoothSpeed = 1;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Vector3.Distance(transform.position, desiredPosition) / smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
