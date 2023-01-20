using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float distance = 10.0f;
    public float angle = 45.0f;
    public float zoomSensitivity = 5.0f;
    public float minDistance = 5.0f;
    public float maxDistance = 20.0f;
    public float smoothTime = 0.1f;

    private Vector3 velocity;

    void Update()
    {
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        distance = Mathf.Clamp(distance - mouseScroll * zoomSensitivity, minDistance, maxDistance);

        Vector3 targetPos = target.position + Quaternion.AngleAxis(angle, Vector3.up) * Vector3.forward * distance + Vector3.up * distance;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        transform.LookAt(target);

        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            CameraManager.cameraClockwise();
            angle = CameraManager.directionMap[CameraManager.cameraAngle].angle;
        }

        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            CameraManager.cameraAntiClockwise();
            angle = CameraManager.directionMap[CameraManager.cameraAngle].angle;
        }
    }
}