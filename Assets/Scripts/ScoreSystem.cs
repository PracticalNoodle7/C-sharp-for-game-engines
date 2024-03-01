using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreSystem : MonoBehaviour
{
    public int score;

    public void AddScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
    }    
}
