using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tgUnlock : Interactable
{
    [SerializeField] Item _item_toUnlock;
    public bool _locked = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cc_player != null)
        {
            if (cc_player.GetComponent<PlayerInput>().GetIsInteracting())
            {
                if (cc_player.GetComponent<Inventory>().GetKeyItemList() != null)
                {
                    for (int i = 0; i < cc_player.GetComponent<Inventory>().GetKeyItemList().Count; i++)
                    {
                        if (cc_player.GetComponent<Inventory>().GetKeyItemList()[i].GetItemName() == _item_toUnlock.GetItemName())_locked = false;
                    }
                }
                
            }
        }
    }
}
