using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    //Declaring other scripts and textMeshPros
    public ScoreSystem scoreSystem;
    public TMPro.TextMeshProUGUI uiLabel;
    public TMPro.TextMeshProUGUI deathScoreLabel;

    private void Update()
    {
        //Updating score on screen
        uiLabel.text = "Score: " + scoreSystem.score;
        deathScoreLabel.text = uiLabel.text;
    }

    //Resets the score when player respawns (After death)
    public void ResetScore()
    {
        scoreSystem.score = 0;
        
    }
}
