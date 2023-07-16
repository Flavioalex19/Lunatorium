using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Transform headTransform;
    [SerializeField] private float bobbingSpeed = 1f; // Speed of the head bobbing
    [SerializeField] private float bobbingAmount = 0.05f; // Amount of head bobbing

    private Vector3 originalPosition;
    private float timer;

    private void Start()
    {
        originalPosition = headTransform.localPosition;
    }

    public void MoveHead(float movementSpeed)
    {
        // Calculate the head bobbing amount based on the movement speed
        float horizontalBobbing = Mathf.Sin(timer * bobbingSpeed) * bobbingAmount * movementSpeed;
        float verticalBobbing = Mathf.Cos(timer * bobbingSpeed * 2f) * bobbingAmount * movementSpeed;

        // Apply the head bobbing to the head's position
        Vector3 targetPosition = originalPosition + new Vector3(horizontalBobbing, verticalBobbing, 0f);
        headTransform.localPosition = Vector3.Lerp(headTransform.localPosition, targetPosition, bobbingSpeed * Time.deltaTime);

        // Increment the timer
        timer += Time.deltaTime;
    }
}
