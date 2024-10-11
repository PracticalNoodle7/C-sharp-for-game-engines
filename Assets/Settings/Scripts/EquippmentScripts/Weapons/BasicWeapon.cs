using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Rendering;

public class BasicWeapon : MonoBehaviour
{
    //Declaring weaponSO and gameobjects
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private GameObject PlayerLocation;

    private void Update()
    {
        //Checking if LMB is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();  
        }
    }
    
    //Fires bullet
    void Attack()
    {
        //Get mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 directionToMouse = (mousePosition - transform.position).normalized;

        if (Vector3.Distance(transform.position, PlayerLocation.transform.position) < 0.01f)
        {   
            //Spawns the bullet at the player's position
            GameObject bulletToSpawn = Instantiate(BulletPrefab, transform.position, Quaternion.identity);

            //Apply force to the bullet in the direction of the mouse location
            if (bulletToSpawn.GetComponent<Rigidbody2D>() != null)
            {
                bulletToSpawn.GetComponent<Rigidbody2D>().AddForce(directionToMouse.normalized * weaponSO.projectileSpeed, ForceMode2D.Impulse);
            }
        }
    }
}
