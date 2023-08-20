using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    [SerializeField] float _hp;
    [SerializeField] float _maxhp;

    private void Start()
    {
        _hp = _maxhp;
    }

    // Update is called once per frame
    void Update()
    {

        if (_hp < 0)
        {
            print("Is out");
            Destroy(gameObject);
        }
        
    }
    public float GetHP()
    {
        return _hp;
    }
    public void TakeDamage(float damage)
    {
        print("Take damage");
        _hp -= damage;
    }

}
