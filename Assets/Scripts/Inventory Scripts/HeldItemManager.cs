using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class HeldItemManager : MonoBehaviour
{
    public EquippedSlotManager[] toolSlot;
    public Transform[] weaponToTransform;

    public Transform weaponManager;
    public Transform character;

    public void CheckIfToolEquipped()
    {
        ResterWeaponLocations();

        for (int i = 0; i < toolSlot.Length; i++)
        {
            if (toolSlot[i].itemName == "BasicBullet")
            {          
                // Sets the character as the parent of basicWeaponManager and assign its position to be the same
                weaponToTransform[0].parent = character;
                weaponToTransform[0].localPosition = Vector3.zero;
            }

            if (toolSlot[i].itemName == "AssultRifle")
            {
                // Sets the character as the parent of basicWeaponManager and assign its position to be the same
                weaponToTransform[1].parent = character;
                weaponToTransform[1].localPosition = Vector3.zero;
            }
        }
    }

    public void ResterWeaponLocations()
    {
        foreach (Transform weaponTransform in weaponToTransform)
        {
            weaponTransform.parent = weaponManager;
            weaponTransform.localPosition = Vector3.zero;
        }
    }
}

