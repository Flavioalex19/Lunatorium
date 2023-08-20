using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tg_HitBox : MonoBehaviour
{
    float _damage;
    bool _dealDamage = false;


    public float GetDamage()
    {
        return _damage;
    }
    public void SetDamage(float damage)
    {
        _damage = damage;
    }
    public bool GetdealDamage()
    {
        return _dealDamage;
    }
    public void SetDealDamage(bool dealdamage)
    {
        _dealDamage = dealdamage;
    }
}
