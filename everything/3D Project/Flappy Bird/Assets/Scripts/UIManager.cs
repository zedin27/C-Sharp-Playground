using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
** UI Scoreboard: https://du-dev.medium.com/creating-score-system-with-ui-in-unity-b24c71ea709f
*/

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    private int score;
    // Start is called before the first frame update
    private SphereCollider playerControlScript;
    void Start()
    {
        playerControlScript = GameObject.Find("Tomato").GetComponent<SphereCollider>();
        scoreText.text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int point)
    {
        score += point;
        scoreText.text = "Score " + score.ToString();
    }
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Pipe"))
    //         AddScore();
    // }
}
