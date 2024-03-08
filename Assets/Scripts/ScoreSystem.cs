using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreSystem : MonoBehaviour
{
    //Declaring varaibles and chests
    public int score;
    public int ScoreOnDeath;
    [SerializeField] private GameObject CommonChest;
    [SerializeField] private GameObject UncommonChest;
    [SerializeField] private GameObject RareChest;
    [SerializeField] private GameObject LegendaryChest;

    //Declaring array of spawn locations for the chests
    [SerializeField] private Transform[] chestSpawnPoints;

    //Updating the score
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    //Checking what chest to spawn based on the player score
    public void RewardTypeChecker()
    {
        // Choose a random spawn point
        Transform randomSpawnPoint = chestSpawnPoints[Random.Range(0, chestSpawnPoints.Length)];

        if (score <= 100)
        {

        }
        else if (score < 200)
        {
            Instantiate(CommonChest, randomSpawnPoint.position, Quaternion.identity);
        }
        else if (score < 350)
        {
            Instantiate(UncommonChest, randomSpawnPoint.position, Quaternion.identity);
        }
        else if (score < 450)
        {
            Instantiate(RareChest, randomSpawnPoint.position, Quaternion.identity);
        }
        else
        {
            Instantiate(LegendaryChest, randomSpawnPoint.position, Quaternion.identity);
        }
    }
}
