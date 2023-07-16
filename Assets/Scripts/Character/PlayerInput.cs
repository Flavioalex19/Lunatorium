using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //Variables
    bool _canInteract = false;
    bool _isInteracting = false;

   

    // Start is called before the first frame update
    void Start()
    {
        //tpm_movement = GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_canInteract)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {

                _isInteracting = true;
            }
        }
    }

    private void FixedUpdate()
    {
        /*
        if(tpm_movement._forward > 0) tpm_movement._isMoving = true;
        else tpm_movement._isMoving = false;
        tpm_movement.MovePlayer();*/
    }
    #region Get & Set
    public bool GetCanInteract()
    {
        return _canInteract;
    }
    public void SetCanInteract(bool canInteract)
    {
        _canInteract = canInteract;
    }
    public bool GetIsInteracting()
    {
        return _isInteracting;
    }
    public void SetIsInteracting(bool isInteracting)
    {
        _isInteracting=isInteracting;
    }
    #endregion
}
