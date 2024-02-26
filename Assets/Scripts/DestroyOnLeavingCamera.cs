using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class DestroyOnLeavingCamera : MonoBehaviour
{
    // Adjust this value as needed
    public float despawnTime = 3f;

    [SerializeField] WeaponSO weaponSO;
    

    private void Update()
    {
        if (CompareTag("Original"))
        {
            Debug.Log("You can live");
        }
        else
        {
            StartCoroutine(DespawnAfterDelay());
        }


    }

    private IEnumerator DespawnAfterDelay()
    {
        // Wait for despawnTime seconds
        yield return new WaitForSeconds(despawnTime);

        
        // Destroy the bullet prefab
        Destroy(gameObject);
    }
}
