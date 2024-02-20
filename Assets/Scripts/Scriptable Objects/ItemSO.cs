using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public AttributeToChange attributeToChange = new AttributeToChange();
    public int ammountToChangeAttribute;

    public bool UseItem()
    {
        
        if (statToChange == StatToChange.health)
        {
            TopDownCharacterHealth pHealth = GameObject.Find("character").GetComponent<TopDownCharacterHealth>();
            if (pHealth.health == pHealth.maxHealth)
            {
                return false;
            }
            else
            {
                pHealth.RestoreHealth(amountToChangeStat);
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
