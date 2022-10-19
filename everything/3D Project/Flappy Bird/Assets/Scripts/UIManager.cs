using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
** UI Scoreboard: https://du-dev.medium.com/creating-score-system-with-ui-in-unity-b24c71ea709f
*/

public class UIManager : MonoBehaviour
{
    public Text scoreBoardTitle;
    public Text scoreBoardDisplay;
    public string scoreText;
    public int score;
    public int oldScore;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoardDisplay.text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (score != oldScore)
        {
            scoreText = score.ToString();
            scoreBoardDisplay.text = "Score: " + scoreText;
            oldScore = score;
        }
    }

    // public void AddScore(int point)
    // {
    //     score += point;
    //     scoreText.text = "Score " + score.ToString();
    // }
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Pipe"))
    //         AddScore();
    // }
}
