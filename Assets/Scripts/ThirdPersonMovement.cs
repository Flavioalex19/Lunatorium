using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] Vector3 playerVelocity;
    [Header("Dash Variables")]
    [SerializeField] float dashDistance = 10f;
    [SerializeField] float dashDuration = 0.2f;
    [SerializeField] float dashCooldown = 2f;
    [SerializeField] float gravity = 9.81f;
    [SerializeField] bool isDashing = false;
    [SerializeField] float dashTimer = 0f;
    [SerializeField] float dashCooldownTimer = 0f;


    CharacterController controller;
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (!isDashing && Input.GetKeyDown(KeyCode.Space) && dashCooldownTimer <= 0f)
        {
            StartDash();
        }
    }

    private void StartDash()
    {
        isDashing = true;
        dashTimer = 0f;

        Vector3 dashDirection = transform.forward;
        dashDirection.y = 0f;
        dashDirection.Normalize();

        playerVelocity = dashDirection * (dashDistance / dashDuration);
    }

    private void FixedUpdate()
    {
        //MovePlayer();
        ApplyGravity();

        /*
        if (isDashing)
        {
            UpdateDash();
        }
        */
    }
    #region Movement
    public void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0f;
        moveDirection.Normalize();

        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 180f);
        }

        controller.Move(moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
    #endregion
    #region Dash
    private void UpdateDash()
    {
        if (dashTimer < dashDuration)
        {
            controller.Move(playerVelocity * Time.fixedDeltaTime);
            dashTimer += Time.fixedDeltaTime;
        }
        else
        {
            isDashing = false;
            playerVelocity = Vector3.zero;
            dashCooldownTimer = 0; // Reset the dash cooldown timer
        }

        if (dashCooldownTimer > 0f)
        {
            dashCooldownTimer -= Time.fixedDeltaTime;
        }
    }
    #endregion
    private void ApplyGravity()
    {
        if (!controller.isGrounded)
        {
            playerVelocity.y -= gravity * Time.fixedDeltaTime;
            controller.Move(playerVelocity * Time.fixedDeltaTime);
        }
        else
        {
            playerVelocity.y = 0f;
        }
    }
}
