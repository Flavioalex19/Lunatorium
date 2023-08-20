using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Item> keyItemsList = new List<Item>(); 

    public List<Powers> _powersList = new List<Powers>();

    Powers _currentPower = null;

    private void Awake()
    {
        if (_powersList.Count > 0)
        {
            _currentPower = _powersList[0];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       // print(_currentPower = _powersList[0]);
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (_powersList != null) _currentPower = _powersList[0];
        
        for (int i = 0; i < _powersList.Count; i++)
        {
            if (_powersList[i].IsOnCooldown)
            {
                if (_powersList[i].Cooldown>0) _powersList[i].Cooldown-=Time.deltaTime;
                else
                {
                    _powersList[i].Cooldown = _powersList[i].ResetCoolDown;
                    _powersList[i].IsOnCooldown = false;
                }
            }
        }
    }

    public void AddToTheList(Item KeyItem)
    {
        keyItemsList.Add(KeyItem);
    }
    public List<Item> GetKeyItemList()
    {
        return keyItemsList;
    }
    public Powers GetCurrentPower()
    {
        return _currentPower;
    }

    public void NextPowerOrb(int index)
    {
        for (int i = 0; i < _powersList.Count; i++)
        {
            if(i == index) _currentPower = _powersList[i];
        }
    }
}
