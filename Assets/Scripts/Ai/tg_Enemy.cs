using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tg_Enemy : MonoBehaviour
{

    EnemyStats _enemyStats;

    private void Start()
    {
        _enemyStats = GetComponent<EnemyStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Projectile")
        {
            print(other.GetComponent<Projectile>().GetDamage());
            _enemyStats.TakeDamage(other.GetComponent<Projectile>().GetDamage());
            other.GetComponent<Projectile>().DestroyProjectile();
        }
    }
}
