using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;

    private float verticalRotation = 0f;
    private float verticalVelocity = 0f;
    float forwardSpeed;

    #region Dash
    [Header("Dash Variables")]
    [SerializeField] float _dashDuration = 0.5f;
    [SerializeField] float _dashSpeed = 10f;
    private float _dashTimer = 0f;
    private bool _isDashing = false;
    #endregion

    private CharacterController characterController;

    UiManager uiManager;
    //[SerializeField]CameraShake cameraShake;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        uiManager = GameObject.Find("UI Manager").GetComponent<UiManager>();
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(uiManager.GetIsDanteLetterDisplayOn()|| uiManager.IsJoshuaLetterDisplayOn())
        {
            // Lock and hide the cursor
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else 
        {
            // Lock and hide the cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            /////
            ///// Rotation (Mouse)
            float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.Rotate(0f, horizontalRotation, 0f);

            verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -60f, 60f);
            Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
            //Dash
            if (_isDashing)
            {
                _dashTimer -= Time.deltaTime;
                if (_dashTimer > 0)
                {
                    Vector3 dashDirection = (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")).normalized * _dashSpeed;
                    characterController.Move(dashDirection * Time.deltaTime);
                }
                else
                {
                    _isDashing = false;
                }
            }
            else
            {
                // Movement (Keyboard)
                forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
                float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

                verticalVelocity += Physics.gravity.y * Time.deltaTime;

                Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
                speed = transform.rotation * speed;

                characterController.Move(speed * Time.deltaTime);
            }

            
        }
        
        
    }
    public void StartDash()
    {
        if (!_isDashing)
        {
            _isDashing = true;
            _dashTimer = _dashDuration;
            verticalVelocity = 0f; // Reset vertical velocity before the dash
        }
    }

}
