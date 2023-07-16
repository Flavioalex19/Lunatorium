using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> keyItemsList = new List<Item>(); 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToTheList(Item KeyItem)
    {
        keyItemsList.Add(KeyItem);
    }
    public List<Item> GetKeyItemList()
    {
        return keyItemsList;
    }
}
