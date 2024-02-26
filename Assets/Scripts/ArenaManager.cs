using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    [SerializeField] GameObject arenaController;
    bool isWaveStarting;
    int amounOfEnemiesInsideArena;
    int maxNumberOfEnemiesInsideArena;
    bool testing;

    public void StartArena()
    {
        if (maxNumberOfEnemiesInsideArena < 10)
        {
            Debug.Log("10 is called");

        }
        if (maxNumberOfEnemiesInsideArena > 10 && maxNumberOfEnemiesInsideArena < 15)
        {
            Debug.Log("15 is called");
        }
    }

    public void Update()
    {
        if (!testing)
        { 
            testing = true;
        }

    }

    public IEnumerator WaveController()
    {
        while(isWaveStarting)
        { 
            yield return null;
        }
        yield return new WaitForSeconds(60);

        TestingBool();
        StopCoroutine(WaveController());

    }

    public void TestingBool()
    {
        testing = false;
    }












}
