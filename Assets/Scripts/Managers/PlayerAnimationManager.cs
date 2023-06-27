using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{

    Animator cc_Animator;
    ThirdPersonMovement cc_ThirdPersonMovement;

    // Start is called before the first frame update
    void Start()
    {
        cc_Animator = GetComponent<Animator>();
        cc_ThirdPersonMovement = GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        cc_Animator.SetBool("isMoving", cc_ThirdPersonMovement._isMoving);
        cc_Animator.SetFloat("Forward", cc_ThirdPersonMovement._forward);
    }
}
