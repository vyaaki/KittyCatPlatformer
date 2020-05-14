using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 curVelocity = Vector3.zero;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public float smoothTime = 0.3f;
    public Transform target;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (target)
        {
            var desiredPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref curVelocity, smoothTime);
        }
    }
}