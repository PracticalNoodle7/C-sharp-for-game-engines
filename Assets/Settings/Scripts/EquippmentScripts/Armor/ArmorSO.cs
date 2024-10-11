using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

[CreateAssetMenu]

public class ArmorSO : ScriptableObject
{
    //Declaring WeaponInfo
    public string ArmorName;
    public int IncreaseHealthAmout;
    public Vector3 spawnLocation;
}
