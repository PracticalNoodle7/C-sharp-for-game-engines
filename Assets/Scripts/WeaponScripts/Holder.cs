using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageDetecter : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().DamageEnemy(weaponSO.damage);
        }
    }



}
