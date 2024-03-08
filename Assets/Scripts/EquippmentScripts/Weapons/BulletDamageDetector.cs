using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageDetecter : MonoBehaviour
{
    //Declaring weapons SO and bullet
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] GameObject BasicBulletPrefab;

    //Destroys bullet on collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Deals damage to enemy
            other.gameObject.GetComponent<EnemyController>().DamageEnemy(weaponSO.damage);
            
        }
        else
        {
            //Destroys bullet if it hits anyhting other than the enemy
            GameObject.Destroy(BasicBulletPrefab);
        }
    }
}
