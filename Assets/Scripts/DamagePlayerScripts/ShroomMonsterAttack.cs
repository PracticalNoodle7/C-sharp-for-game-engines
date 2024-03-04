using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.WSA;

public class ShroomMonsterAttack : MonoBehaviour
{

    TopDownCharacterController characterController;
    public float damage;
    bool hasAttacked;

    private void Start()
    {
        characterController = GameObject.Find("character").GetComponent<TopDownCharacterController>();
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {                     
            hasAttacked = true;  
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        while (!hasAttacked)
        {
            yield return null;
        }            
        
        characterController.health -= damage;
        yield return new WaitForSeconds(2);
        hasAttacked = false;
        StopCoroutine(Attack());
    }        


}
