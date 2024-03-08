using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootinEnemyAttack : MonoBehaviour
{
    //Declaring other scripts and varaibles
    TopDownCharacterController characterController;
    [SerializeField] private GameObject EnemyBullet;
    [SerializeField] private float projectileSpeed;

    private void Start()
    {
        //Manually finding the character script to help avoid errors
        characterController = GameObject.Find("character").GetComponent<TopDownCharacterController>();
    }

    //starts the enemy attack when the event is called at the end of the animation
    private void Attack()
    {
        //Getting the direction towards the player
        Vector3 directionToPlayer = (characterController.transform.position - transform.position ).normalized;

        //Spawning the bullet at the enemy location
        GameObject bulletToSpawn = Instantiate(EnemyBullet, transform.position, Quaternion.identity );

        // Applying force to the bullet towards the player 
        if (bulletToSpawn.GetComponent<Rigidbody2D>() != null)
        {
            bulletToSpawn.GetComponent<Rigidbody2D>().AddForce(directionToPlayer * projectileSpeed, ForceMode2D.Impulse);
        }

    }
}
