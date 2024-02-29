using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new();
    public int amountToChangeStat;

    public AttributeToChange attributeToChange = new();
    public int ammountToChangeAttribute;

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
        if(statToChange == StatToChange.stamina)
        {
            //apply stamina change here
        }
        return false;
    }

    public enum StatToChange
    {
        none,
        health,
        stamina
    };

    public enum AttributeToChange
    {
        none,
        strength,
        defense,
        intelligence,
        agility
    };    
}
