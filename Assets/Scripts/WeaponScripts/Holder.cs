using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageDetecter : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] GameObject BasicBulletPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().DamageEnemy(weaponSO.damage);
            
        }
        else
        {
            GameObject.Destroy(BasicBulletPrefab);
        }
        
        Destroy(BasicBulletPrefab);
    }
}
