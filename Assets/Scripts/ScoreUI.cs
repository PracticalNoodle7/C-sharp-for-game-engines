using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public scoreSystem scoreSystem;
    public TMPro.TextMeshProUGUI uiLabel;
    public TMPro.TextMeshProUGUI deathScoreLabel;

    private void Update()
    {
        uiLabel.text = "Score: " + scoreSystem.score;
        deathScoreLabel.text = uiLabel.text;
    }

    public void ResetScore()
    {
        scoreSystem.score = 0;
        
    }
}
