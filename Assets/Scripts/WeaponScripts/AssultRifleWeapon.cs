using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssultRifleWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private GameObject PlayerLocation;
    private bool buttonHeld = false;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            buttonHeld = true;
        }

        if (Input.GetButton("Fire1"))
        {
            if (buttonHeld)
            {
                
                Attack();
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            buttonHeld = false;
        }
    }

    void Attack()
    {

        // Get mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 directionToMouse = (mousePosition - transform.position).normalized;

        if (Vector3.Distance(transform.position, PlayerLocation.transform.position) < 0.01f)
        {
            // Instantiate the bullet at the player's position
            GameObject bulletToSpawn = Instantiate(BulletPrefab, transform.position, Quaternion.identity);

            // Apply force to the bullet in the direction of the mouse
            if (bulletToSpawn.GetComponent<Rigidbody2D>() != null)
            {
                bulletToSpawn.GetComponent<Rigidbody2D>().AddForce(directionToMouse.normalized * weaponSO.projectileSpeed, ForceMode2D.Impulse);
            }
        }
    }
}
