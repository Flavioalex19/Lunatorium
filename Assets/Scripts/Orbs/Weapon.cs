using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Weapon : MonoBehaviour
{

    public Powers _weaponPower;

    public float FireRate;
    public bool CanShoot = true;
    public float FireTimer = 0f;

    public float speed = 10f;

    public Transform ProjectileSpawnPoint;

    Inventory _inventory;

    //Change dis to each power
    [SerializeField]Animator _anim_Orb;

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        if (_inventory.GetCurrentPower() != null)
        {

            _weaponPower = _inventory.GetCurrentPower();

        }
        

        _weaponPower.IsOnCooldown = false;

        _weaponPower.Cooldown = _weaponPower.ResetCoolDown;
    }

    private void Update()
    {
     
        _weaponPower = _inventory.GetCurrentPower();

        #region Fire Orb
        FireTimer += Time.deltaTime;   
        if (FireTimer >= FireRate)
        {
            CanShoot = true;
            //FireTimer = 0;
        }
        #endregion

    }


    public void FireEnergy(Stats stats)
    {
        if (CanShoot)
        {
            if (_weaponPower.IsARecoveringPower)
            {
                if(_weaponPower.IsOnCooldown == false)
                {
                    _weaponPower.IsOnCooldown = true;
                    //mind += _weaponPower.Damage;
                    stats.SetCurrentMind(stats.GetCurrentMind() + _weaponPower.Damage);
                    CanShoot = false;
                }
                
            }
            else
            {
                //_sfx_rifle.Play();
                
                GameObject bullet = Instantiate(_weaponPower.ProjectilePrefab, ProjectileSpawnPoint.position, ProjectileSpawnPoint.rotation);
                _weaponPower.ProjectilePrefab.GetComponent<Projectile>().SetDamage(_weaponPower.Damage);
                bullet.GetComponent<Projectile>().SetDamage(_weaponPower.Damage);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                bulletRigidbody.velocity = ProjectileSpawnPoint.forward * _weaponPower.ProjectileSpeed;
                stats.SetCurrentMind(stats.GetCurrentMind() -_weaponPower.CastingCost);
                //print(_weaponPower.ProjectilePrefab.GetComponent<Projectile>().GetDamage());
                _anim_Orb.SetTrigger("Fire");
                FireTimer = 0f;
                CanShoot = false;
            }
            

        }
       
    }

}
