using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclesPrefab;
    private PlayerControl playerControllerScript;
    public UIManager UIManagerScript;
    private float startDelay = 1.69f;
    private float repeatRate = 1.1f;
    void Start()
    {
        playerControllerScript = GameObject.Find("Tomato").GetComponent<PlayerControl>();
        UIManagerScript = GameObject.Find("UI_Manager").GetComponent<UIManager>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            float randomY = Random.Range(-2f, 2f);
            Vector3 randomHeight = new Vector3(35, randomY, -7);
            GameObject pipe = ObjectPooling.sharedInstance.GetPooledObject();
            if (pipe != null)
            {
                pipe.transform.position = randomHeight;
                pipe.SetActive(true);
                UIManagerScript.incrementScore = false;
                UIManagerScript.success = false;
            }
        }
    }
}
