using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //Variables
    bool _canInteract = false;
    bool _isInteracting = false;

    public bool _isInCombat = false;

    Stats _stats;
    Weapon _weapon;
    Inventory _inventory;
    FpsMovement _fpsMovement;

    // Start is called before the first frame update
    void Start()
    {
        //tpm_movement = GetComponent<ThirdPersonMovement>();
        _stats = GetComponent<Stats>();
        _inventory = GetComponent<Inventory>();
        _weapon = GameObject.Find("Weapon").GetComponent<Weapon>();
        _fpsMovement = GetComponent<FpsMovement>();
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
        if(_isInCombat && Input.GetKeyDown(KeyCode.Space))
        {
            _fpsMovement.StartDash();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && _isInCombat)
        {
            _weapon.FireEnergy(_stats);
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _inventory.NextPowerOrb(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _inventory.NextPowerOrb(1);
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
