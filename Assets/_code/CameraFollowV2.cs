using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class CameraFollowV2 : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;
    public float smoothTime;
    [MinMaxSlider(0.0f, 200.0f)]
    public Vector2 maxMinZoom = new Vector2(40f, 120f);
    float minZoom;
    float maxZoom;
    public float zoomLimiter;
    Vector3 velocity;
    Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void FixedUpdate()
    {
        if (targets.Count == 0)
            return;
        minZoom = maxMinZoom.y;
        maxZoom = maxMinZoom.x;
        Move();
        Zoom();
    }
    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetCenterPoint(true).x / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }
    void Move()
    {
        Vector3 centerPoint = GetCenterPoint(false);

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
    Vector3 GetCenterPoint(bool isGetDist)
    {
        if (targets.Count == 1 && !isGetDist)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        if(isGetDist)
            return new Vector3(bounds.size.x,0,0);
        else
            return bounds.center;
    }
}
