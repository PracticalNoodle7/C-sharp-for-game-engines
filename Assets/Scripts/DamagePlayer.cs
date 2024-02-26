using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public TopDownCharacterHealth pHealth;
    public float damage;

    public void Start()
    {
       // pHealth = GameObject.Find("character").GetComponent<>(TopDownCharacterHealth);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pHealth.health -= damage;
        }
    }
}
