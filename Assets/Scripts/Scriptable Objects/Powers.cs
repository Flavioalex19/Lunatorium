using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "KeyItem")]
public class Powers : ScriptableObject
{
    public GameObject ProjectilePrefab;

    public float Damage;//If is a recovering orb instead of dealing damage you will heal our mind
    public float CastingCost;
    public float ResetCoolDown = 10f;
    public float Cooldown;
    public float ProjectileSpeed = 10f;
    public bool IsARecoveringPower = false;
    public bool IsOnCooldown = false;
    public bool IsActive = false;

    
}
