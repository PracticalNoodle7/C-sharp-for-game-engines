using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssultRifleWeapon : MonoBehaviour
{
    //Declaring weaponsSO, gameobjects and varaibles
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private GameObject PlayerLocation;
    private bool buttonHeld = false;
    private bool canShoot = true;

    private void Update()
    {
        //Checking if LMB is down
        if (Input.GetButtonDown("Fire1"))
        {
            //Sets buttonHeld to true
            buttonHeld = true;
            
            //Reset canShoot when the fire button is pressed
            canShoot = true; 
        }

        //Checks if LMB is pressed
        if (Input.GetButton("Fire1"))
        {
            //Checkis if variables are both true
            if (buttonHeld && canShoot)
            {
                //Starts coroutine to fire bullet and wait till it can fire again
                StartCoroutine(ShootAndWait());

                // Set canShoot to false after shooting
                canShoot = false;
            }
        }

        //Resets varables when LMB is not being pressed anymore
        if (Input.GetButtonUp("Fire1"))
        {
            buttonHeld = false;
        }
    }

    //Start attack and then wait for FireRate timer to be over
    IEnumerator ShootAndWait()
    {
        while (buttonHeld)
        {
            Attack();
            yield return new WaitForSeconds(weaponSO.FireRate);
        }
    }

    //Fires bullet method
    void Attack()
    {
        //Get mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 directionToMouse = (mousePosition - transform.position).normalized;

        if (Vector3.Distance(transform.position, PlayerLocation.transform.position) < 0.01f)
        {
            //Spawns the bullet at the player's position
            GameObject bulletToSpawn = Instantiate(BulletPrefab, transform.position, Quaternion.identity);

            //Apply force to the bullet in the direction of the mouse
            if (bulletToSpawn.GetComponent<Rigidbody2D>() != null)
            {
                bulletToSpawn.GetComponent<Rigidbody2D>().AddForce(directionToMouse.normalized * weaponSO.projectileSpeed, ForceMode2D.Impulse);
            }
        }
    }
}
