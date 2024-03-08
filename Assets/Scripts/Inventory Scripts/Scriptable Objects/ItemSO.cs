using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    //Delcaring item data
    public string itemName;
    public StatToChange statToChange = new();
    public int amountToChangeStat;

    //Decides if item can be used and reutrns a bool
    public bool UseItem()
    {
        
        if (statToChange == StatToChange.health)
        {
            TopDownCharacterController characterController = GameObject.Find("character").GetComponent<TopDownCharacterController>();
            if (characterController.health == characterController.maxHealth)
            {
                return false;
            }
            else
            {
                characterController.RestoreHealth(amountToChangeStat);
                return true;
            }
        }
        return false;
    }

    public enum StatToChange { none, health}; 
}
