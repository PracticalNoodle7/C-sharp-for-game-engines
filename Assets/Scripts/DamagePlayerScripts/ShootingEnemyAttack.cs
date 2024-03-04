using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMonsterAttack : MonoBehaviour
{
    TopDownCharacterController characterController;
    [SerializeField] private GameObject EnemyBullet;
    [SerializeField] private float projectileSpeed;

    private void Start()
    {
        characterController = GameObject.Find("character").GetComponent<TopDownCharacterController>();
    }

    private void Attack()
    {
        // Calculate direction from enemy to player
        Vector3 directionToPlayer = (characterController.transform.position - transform.position ).normalized;

        // Instantiate the bullet at the enemy's position
        GameObject bulletToSpawn = Instantiate(EnemyBullet, transform.position, Quaternion.identity );

        // Apply force to the bullet towards the player's position
        if (bulletToSpawn.GetComponent<Rigidbody2D>() != null)
        {
            bulletToSpawn.GetComponent<Rigidbody2D>().AddForce(directionToPlayer * projectileSpeed, ForceMode2D.Impulse);
        }

    }





}
