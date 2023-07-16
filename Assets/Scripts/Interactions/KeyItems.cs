using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItems : Interactable
{

    [SerializeField] Item _keyItem;

    Inventory _inventory;

    private void Start()
    {
        _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {

        if (cc_player != null)
        {
            if (_keyItem != null)
            {
                if (cc_player.GetComponent<PlayerInput>().GetIsInteracting())
                {
                    cc_player.GetComponent<Inventory>().AddToTheList(_keyItem);
                    cc_player.GetComponent<PlayerInput>().SetIsInteracting(false);
                    Destroy(gameObject);
                }
            }
        }
        
    }
}
