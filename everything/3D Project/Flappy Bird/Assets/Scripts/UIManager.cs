using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
** UI Scoreboard: https://du-dev.medium.com/creating-score-system-with-ui-in-unity-b24c71ea709f
*/

public class UIManager : MonoBehaviour
{
    public Text scoreBoardDisplay;
    public Text scoreBoardDisplayShadowed;
    public AudioSource sound_score;
    public string scoreText;
    public int score;
    public int oldScore;
    public bool success;
    public bool incrementScore;
    
    void Start()
    {
        success = false;
        incrementScore = false;
    }

    void Update()
    {
        if (score != oldScore)
        {
            sound_score.Play();
            scoreText = score.ToString();
            scoreBoardDisplay.text = scoreText;
            scoreBoardDisplayShadowed.text = scoreText;
            oldScore = score;
        }
    }
}
