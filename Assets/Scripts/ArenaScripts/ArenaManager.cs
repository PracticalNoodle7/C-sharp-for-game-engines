using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TMPro.Examples;
using Unity.Collections;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    [SerializeField] GameObject arenaController;
    bool isWaveStarting;
    int amountOfEnemiesInsideArena;
    int maxNumberOfEnemiesInsideArena;
    bool testing;
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;

    public void Update()
    {
        if (!testing)
        {
            StartCoroutine(WaveController());
            testing = true;
        }

        if (amountOfEnemiesInsideArena < maxNumberOfEnemiesInsideArena)
        {
            SpawnEnemy();
        }
    }


    public void StartArena()
    {        
        StopCoroutine(WaveController());

        if (maxNumberOfEnemiesInsideArena >= 30 && maxNumberOfEnemiesInsideArena < 35)
        {
            Debug.Log("35 is called");
            maxNumberOfEnemiesInsideArena = 35;
        }
        if (maxNumberOfEnemiesInsideArena >= 25 && maxNumberOfEnemiesInsideArena < 30)
        {
            Debug.Log("30 is called");
            maxNumberOfEnemiesInsideArena = 30;
        }
        if (maxNumberOfEnemiesInsideArena >= 20 && maxNumberOfEnemiesInsideArena < 25)
        {
            Debug.Log("25 is called");
            maxNumberOfEnemiesInsideArena = 25;
        }
        if (maxNumberOfEnemiesInsideArena >= 15 && maxNumberOfEnemiesInsideArena < 20)
        {
            Debug.Log("20 is called");
            maxNumberOfEnemiesInsideArena = 20;
        }
        if (maxNumberOfEnemiesInsideArena >= 10 && maxNumberOfEnemiesInsideArena < 15)
        {
            Debug.Log("15 is called");
            maxNumberOfEnemiesInsideArena = 15;
        }
        if (maxNumberOfEnemiesInsideArena < 10)
        {
            Debug.Log("10 is called");
            maxNumberOfEnemiesInsideArena = 10;
        }


        StartCoroutine(WaveController());
    }


    public IEnumerator WaveController()
    {
        while(isWaveStarting)
        { 
            yield return null;
        }
        yield return new WaitForSeconds(Random.Range(120, 417));

        StartArena();
    }

    private void SpawnEnemy()
    {
        // Choose a random spawn point
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Choose a random enemy prefab
        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Spawn the random enemy at the random spawn point
        GameObject enemyToSpawn = Instantiate(randomEnemyPrefab, randomSpawnPoint.position, Quaternion.identity);

        // If the spawned enemy has a Rigidbody2D component, you can access it like this
        Rigidbody2D enemyRb = enemyToSpawn.GetComponent<Rigidbody2D>();

        if (enemyRb != null)
        {
            // Do something with the Rigidbody2D component if needed
        }

    }










}
