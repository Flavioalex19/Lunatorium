using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] float _currentMind;
    [SerializeField] float _mind;

    public bool _isUnderPressure = false;//If the player is on combat

    // Start is called before the first frame update
    void Start()
    {
        _currentMind = _mind;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isUnderPressure)
        {
            _currentMind -= Time.deltaTime;
        }
    }

    public float GetCurrentMind()
    {
        return _currentMind;
    }
    public float GetMind()
    {
        return _mind;
    }
    public void SetCurrentMind(float mind)
    {
        _currentMind = mind;
    }
    public void SetMind(float mind)
    {
        _mind = mind;
    }
    public bool GetIsUnderPressure()
    {
        return _isUnderPressure;
    }
    public void SetIsUnderPress(bool myBool)
    {
        _isUnderPressure = myBool;
        
    }
    public void RestoreMind()
    {
        _currentMind = _mind;
    }
    void TakeDamage(float damage)
    {
        _currentMind -= damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hitbox" && other.GetComponent<tg_HitBox>().GetdealDamage())
        {
            print("Being hit");
            TakeDamage(other.GetComponent<tg_HitBox>().GetDamage());
        }
    }
}
