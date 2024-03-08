using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UIElements;

public class IncreaseStats : MonoBehaviour
{
    //Declaring armor scriptable object and player
    [SerializeField] ArmorSO armorSO;
    [SerializeField] private GameObject PlayerLocation;

    //Declaing other scripts and variables
    TopDownCharacterController characterController;
    private bool Updated = false;

    private void Start()
    {
        //Manually finding character script to helpt avoid errors
        characterController = GameObject.Find("character").GetComponent<TopDownCharacterController>();
    }

    public void Update()
    {
        //checking to see if the armor is roughly = to player location and updated is false
        if (Vector3.Distance(transform.position, PlayerLocation.transform.position) < 0.01f && !Updated)
        {
            //Calling the updatestats method and setting updating to true so this isn't called constantly
            UpdateStats();
            Updated = true;
        }

        //Checking to see if the armor isn't near the player and updated is true
        if (Vector3.Distance(transform.position, PlayerLocation.transform.position) > 0.01f && Updated)
        {
            //Resets the player stats to defult and resets updated to false
            ResetStats();
            Updated = false;
        }
    }

    //Upsating the player stats depending on the armors stats
    public void UpdateStats()
    {
        //Reseting player stats so stats are stacked
        ResetStats();

        //checking is armor is increasing health
        if (armorSO.IncreaseHealthAmout > 0)
        {
            //checking if health is = to max health
            if (characterController.health == characterController.maxHealth)
            {
                //Adds armor health boost to both stats so they are still equal
                characterController.maxHealth += armorSO.IncreaseHealthAmout;
                characterController.health += armorSO.IncreaseHealthAmout;
            }
            //Checking if health is less than max health
            else if (characterController.health < characterController.maxHealth)
            {
                //Only increases maxhealth
                characterController.maxHealth += armorSO.IncreaseHealthAmout;
            }
        }
    }

    //Reseting stats back to normal
    private void ResetStats()
    {
        characterController.maxHealth = 100;

        //Reducing player helth to match max health if it is greater or = to max health
        if (characterController.health >= characterController.maxHealth)
        {
            characterController.health = characterController.maxHealth;
        }
    }
}
