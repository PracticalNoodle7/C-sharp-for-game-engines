using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RewardChesLoot : MonoBehaviour
{    
    //Declaring items
    [SerializeField] private GameObject healingPotions;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject armor;
    [SerializeField] private GameObject relic;

    //Declaring animator
    private Animator animator;

    //Declaring weapon drop chance
    private float weaponDropChance = 0.25f;

    void Start()
    {
        //Get the attached components so we can use them later
        animator = GetComponent<Animator>();
    }

    //When player enters trigger it will start the animation of opening the chest
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
                animator.SetBool("PlayerClose", true);
        }
    }

    //Deciding what loot to spawn
    public void OpenChest()
    {            
        //gets a random number between 0 and 1
        float randomValue = Random.value;

        if (weapon != null)
        {
            //checks if random number is less them chance to drop weapon
            if (randomValue < weaponDropChance)
            {
                //Spawns weapon
                Instantiate(weapon, transform.position, Quaternion.identity);
            }
        }            
        
        //checks if random number is more them chance to drop weapon
        if (armor != null)
        {
            if (randomValue > weaponDropChance)
            {
                //Spawns armor
                Instantiate(armor, transform.position, Quaternion.identity);
            }
        }

        //Spawns healing potions
        if (healingPotions != null)
        {
            for (int i = 0; i < Random.Range(2, 4); i++)
            {
                Instantiate(healingPotions, transform.position, Quaternion.identity);
            }
        }

        //Destroys chest
        Destroy(gameObject);
    }
}
