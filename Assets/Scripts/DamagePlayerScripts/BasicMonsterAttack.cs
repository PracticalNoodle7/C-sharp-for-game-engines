using System.Collections;
using UnityEngine;

public class BasicMonsterAttack : MonoBehaviour
{
    //Declares other scripts and variables
    TopDownCharacterController characterController;
    public float damage;
    bool hasAttacked;

    private void Start()
    {
        //Manually finds character script to help avoid errors
        characterController = GameObject.Find("character").GetComponent<TopDownCharacterController>();
    }

    //Tells the enemy to attack when they collide with the player
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {                     
            hasAttacked = true;  
            StartCoroutine(Attack());
        }
    }

    //Starts a corouting to prevent the enemy from dealing the damage multiple times within a second
    IEnumerator Attack()
    {
        while (!hasAttacked)
        {
            yield return null;
        }            
        
        characterController.health -= damage;
        yield return new WaitForSeconds(2);
        hasAttacked = false;
        
        //Resets the corouting so they can damage the player again
        StopCoroutine(Attack());
    }        


}
