using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class HeldItemManager : MonoBehaviour
{
    public EquippedSlotManager[] equippedSlot;
    public GameObject BasicWeaponManager;
    
    private void Update()
    {
        for (int i = 0; i < equippedSlot.Length; i++)
        {
            if (equippedSlot[i].itemName == "BasicBullet")
            {
                BasicWeaponManager.transform.position = transform.position;
            }
        }

    }
























}

