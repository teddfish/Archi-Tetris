using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform roTarget;
    Transform target;
    Vector3 lastPosition;
    float sensitivity = 0.25f;

    // Start is called before the first frame update
    void Awake()
    {
        roTarget = transform.parent;
        target = roTarget.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        if (Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
        }
        Orbit();
    }

    // Implement Camera Orbit here
    void Orbit()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastPosition;
            float angleY = -delta.y * sensitivity;
            float angleX = delta.x * sensitivity;

            //X Axis
            Vector3 angles = roTarget.transform.eulerAngles;
            angles.x += angleY;
            angles.x = ClampAngle(angles.x, -80, 80);
            roTarget.transform.eulerAngles = angles;

            //Y Axis
            target.RotateAround(target.position, Vector3.up, angleX);
            lastPosition = Input.mousePosition;
        }
    }

    // Clamp the upward angle to -85 and 85 degrees
    float ClampAngle(float angle, float from, float to)
    {
        if (angle < 0f) angle = 360 + angle;

        if (angle > 180f) return Mathf.Max(angle, 360 + from);

        return Mathf.Min(angle, to);
    }
}
