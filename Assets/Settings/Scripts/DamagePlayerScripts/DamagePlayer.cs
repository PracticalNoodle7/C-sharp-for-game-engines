using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    //Declaring other scripts and variables
    TopDownCharacterController characterController;
    public float damage;
    [SerializeField] private GameObject EnemyBulletPrefab;

    public void Start()
    {
        //Manually finding the character script to help avoid errors
        characterController = GameObject.Find("character").GetComponent<TopDownCharacterController>();
    }

    //When enemy bullet collides with player then Destroys itself
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            characterController.health -= damage;
            GameObject.Destroy(EnemyBulletPrefab);
        }
        else
        {
            //Destroys bullet when it hits anything that has a valid collision
            GameObject.Destroy(EnemyBulletPrefab);
        }
    }
}
