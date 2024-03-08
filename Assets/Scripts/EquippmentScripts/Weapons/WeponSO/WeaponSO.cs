using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class WeaponSO : ScriptableObject
{
    //Declaring WeaponInfo
    public string weaponName;
    public int damage;
    public float projectileSpeed;
    public float FireRate;
    public Vector3 spawnLocation;

    public bool FireBullet()
    {
        return false;
    }
}
