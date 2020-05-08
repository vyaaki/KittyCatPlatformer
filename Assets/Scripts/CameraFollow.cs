using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float smoothTime = 0.3f;
    public Vector3 offset;
    private Vector3 curVelocity = Vector3.zero;
    void Update()
    {
        if (target)
        {
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref curVelocity, smoothTime);
        }
    }
}
