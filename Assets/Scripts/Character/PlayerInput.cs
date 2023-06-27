using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    ThirdPersonMovement tpm_movement;

    // Start is called before the first frame update
    void Start()
    {
        tpm_movement = GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(tpm_movement._forward > 0) tpm_movement._isMoving = true;
        else tpm_movement._isMoving = false;
        tpm_movement.MovePlayer();
    }
}
