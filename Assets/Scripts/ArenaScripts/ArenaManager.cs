using System.Collections;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    //Declaring arena enterance
    [SerializeField] GameObject EnterArena;

    //Delcaring varaibles
    int CurrentlySpawnedEnemys;
    int maxNumberOfEnemiesInsideArena;

    //Delcaring arrays of enemts and spawn points
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;

    //Declaring player controller script
    TopDownCharacterController characterController;

    public void Start()
    {
        //Manutally finding player controller script to help avoid errors
        characterController = GameObject.Find("character").GetComponent<TopDownCharacterController>();
    }

    private void Update()
    {
        //Reseting arena if player is dead
        if (characterController.isDead == true)
        {
            StopAllCoroutines();
            maxNumberOfEnemiesInsideArena = 0;
        }
    }

    //Updating enemy count when enemy spawns
    public void AddToEnemyCount()
    {
        CurrentlySpawnedEnemys += 1;
    }

    //Updating enemy count when enemy dies
    public void MinusFromEnemyCount()
    {
        CurrentlySpawnedEnemys -= 1;
    }

    //starting the arena
    public void StartArena()
    {
        //Setting enemy count to 0 and starting wave controller and delay enemy spawn coroutine
        CurrentlySpawnedEnemys = 0;
        WaveDifficultyController();
        StartCoroutine(DelayEnemySpawning());
    }

    //Controlling the wave difficulty
    public void WaveDifficultyController()
    {        
        //Stopping the wave controller coroutine so the timer can be reset
        StopCoroutine(WaveController());

        //Deciding what to increase the max enemy count to depending on the current max enemy count
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

        //Restarting the countdown to increase the difficulty again
        StartCoroutine(WaveController());
    }

    //Corouting to wait before increasing the difficulty again
    public IEnumerator WaveController()
    {
        yield return new WaitForSeconds(15);

        WaveDifficultyController();
    }

    //Preventing enemys from spawning all at once with a delay 
    public IEnumerator DelayEnemySpawning()
    {
        yield return new WaitForSeconds(2);

        //Calls spawn enemy method
        SpawnEnemy();
    }

    //Decides what enemy and where to spawn them
    private void SpawnEnemy()
    {
        //Stops toe coroutine so the timer can be reset later
        StopCoroutine(DelayEnemySpawning());

        if (CurrentlySpawnedEnemys < maxNumberOfEnemiesInsideArena)
        {
            //Chooses a random spawn point
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            //Chooses a random enemy
            GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            //Spawns the choosen enemy at the choosen spawn point
            Instantiate(randomEnemyPrefab, randomSpawnPoint.position, Quaternion.identity);
        }

        //Resets the timer to then spawn another enemy
        StartCoroutine(DelayEnemySpawning());
    }

    //kills all remaining enenmys once the player has died 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (characterController.isDead == true)
        {
            //Waits for a seconds to ensure all enemys has spawned before destroying them
            StartCoroutine(WaitForSeconds());

            if (collision.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject);
            }

            //Resets the timer for later
            StopCoroutine(WaitForSeconds());
        }
    }
    
    //Coroutine that pauses the script for 2 seconds
    public IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(2);
    }
}
