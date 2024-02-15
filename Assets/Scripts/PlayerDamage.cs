using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public float damage;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")) 
        {
            other.gameObject.GetComponent<EnemyController>().DamageEnemy(damage);
        }
    }


}

