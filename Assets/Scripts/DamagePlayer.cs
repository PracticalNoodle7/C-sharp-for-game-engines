using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    TopDownCharacterController characterController;
    public float damage;

    public void Start()
    {
        characterController = GameObject.Find("character").GetComponent<TopDownCharacterController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            characterController.health -= damage;
        }
    }
}
