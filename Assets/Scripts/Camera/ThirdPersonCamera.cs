using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;  // Target object to follow
    public float distance = 5.0f;  // Distance from the target
    public float height = 2.0f;  // Height offset from the target
    public float rotationDamping = 3.0f;  // Speed of camera rotation
    public float verticalDamping = 2.0f;  // Speed of camera vertical movement

    public float minVerticalAngle = -60.0f;  // Minimum vertical angle
    public float maxVerticalAngle = 60.0f;   // Maximum vertical angle

    private float currentRotationAngle;
    private float currentVerticalAngle;
    private float desiredRotationAngle;
    private float desiredVerticalAngle;
    private Quaternion currentRotation;
    private Quaternion desiredRotation;

    private void Start()
    {
        // Set the initial rotation angles
        currentRotationAngle = transform.eulerAngles.y;
        currentVerticalAngle = transform.eulerAngles.x;
        desiredRotationAngle = currentRotationAngle;
        desiredVerticalAngle = currentVerticalAngle;

        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        // Hide the cursor
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        // Check if target is set
        if (!target)
            return;

        // Calculate desired rotation and vertical angle
        desiredRotationAngle += Input.GetAxis("Mouse X") * rotationDamping;
        desiredVerticalAngle -= Input.GetAxis("Mouse Y") * verticalDamping;

        // Clamp the vertical angle
        desiredVerticalAngle = ClampAngle(desiredVerticalAngle, minVerticalAngle, maxVerticalAngle);

        // Calculate desired rotation
        desiredRotation = Quaternion.Euler(desiredVerticalAngle, desiredRotationAngle, 0);

        // Smoothly interpolate between the current rotation and desired rotation
        currentRotation = Quaternion.Lerp(currentRotation, desiredRotation, rotationDamping * Time.deltaTime);

        // Calculate desired camera position
        Vector3 offset = new Vector3(0, height, -distance);
        Vector3 desiredPosition = target.position + (currentRotation * offset);

        // Update camera position and rotation
        transform.position = desiredPosition;
        transform.LookAt(target.position + Vector3.up * height);
    }

    // Clamp an angle between a minimum and maximum value
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
