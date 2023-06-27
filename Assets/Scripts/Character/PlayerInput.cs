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
        tpm_movement.MovePlayer();
    }
}
