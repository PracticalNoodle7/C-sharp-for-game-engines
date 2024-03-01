using System.Collections;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    [SerializeField] GameObject EnterArena;
    int CurrentlySpawnedEnemys;
    int maxNumberOfEnemiesInsideArena;
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    TopDownCharacterController characterController;

    public void Start()
    {
        characterController = GameObject.Find("character").GetComponent<TopDownCharacterController>();
    }

    private void Update()
    {
        if (characterController.isDead == true)
        {
            StopAllCoroutines();
            maxNumberOfEnemiesInsideArena = 0;
        }
    }

    public void AddToEnemyCount()
    {
        CurrentlySpawnedEnemys += 1;
    }

    public void MinusFromEnemyCount()
    {
        CurrentlySpawnedEnemys -= 1;
    }

    public void StartArena()
    {
        CurrentlySpawnedEnemys = 0;
        WaveDifficultyController();
        StartCoroutine(DelayEnemySpawning());
    }

    public void WaveDifficultyController()
    {        
        StopCoroutine(WaveController());

        if (maxNumberOfEnemiesInsideArena >= 30 && maxNumberOfEnemiesInsideArena < 35)
        {
            maxNumberOfEnemiesInsideArena = 35;
        }
        if (maxNumberOfEnemiesInsideArena >= 25 && maxNumberOfEnemiesInsideArena < 30)
        {
            maxNumberOfEnemiesInsideArena = 30;
        }
        if (maxNumberOfEnemiesInsideArena >= 20 && maxNumberOfEnemiesInsideArena < 25)
        {
            maxNumberOfEnemiesInsideArena = 25;
        }
        if (maxNumberOfEnemiesInsideArena >= 15 && maxNumberOfEnemiesInsideArena < 20)
        {
            maxNumberOfEnemiesInsideArena = 20;
        }
        if (maxNumberOfEnemiesInsideArena >= 10 && maxNumberOfEnemiesInsideArena < 15)
        {
            maxNumberOfEnemiesInsideArena = 15;
        }
        if (maxNumberOfEnemiesInsideArena < 10)
        {
            maxNumberOfEnemiesInsideArena = 10;
        }

        StartCoroutine(WaveController());
    }

    public IEnumerator WaveController()
    {
        yield return new WaitForSeconds(20);

        WaveDifficultyController();
    }

    public IEnumerator DelayEnemySpawning()
    {
        yield return new WaitForSeconds(2);

        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        StopCoroutine(DelayEnemySpawning());

        if (CurrentlySpawnedEnemys < maxNumberOfEnemiesInsideArena)
        {
            // Choose a random spawn point
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Choose a random enemy prefab
            GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Spawn the random enemy at the random spawn point
            Instantiate(randomEnemyPrefab, randomSpawnPoint.position, Quaternion.identity);
        }

        StartCoroutine(DelayEnemySpawning());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (characterController.isDead == true)
        {
            StartCoroutine(WaitForSeconds());

            if (collision.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
            }
            StopCoroutine(WaitForSeconds());
        }
    }
    public IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(2);
    }
}
