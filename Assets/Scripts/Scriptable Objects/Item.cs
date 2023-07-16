using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyItem")]
public class Item : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] string description;
    [SerializeField]Sprite ui_menu_item_sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetItemName()
    {
        return itemName;
    }
}
