using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclesPrefab;
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerControl playerControllerScript;
    float gap = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Tomato").GetComponent<PlayerControl>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        int obstaclesIndex = Random.Range(0, obstaclesPrefab.Length);
        float randomY = Random.Range(-1.5f, 2.5f);
        Vector3 randomHeight = new Vector3(35, randomY, -10);
        Vector3 randomHeight2 = new Vector3(35, randomY + gap, -10);
        
        // obstaclesPrefab[obstaclesIndex].GetComponent<BoxCollider>().enabled = true;
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclesPrefab[obstaclesIndex], randomHeight, obstaclesPrefab[obstaclesIndex].transform.rotation);
            Instantiate(obstaclesPrefab[obstaclesIndex], randomHeight2, obstaclesPrefab[obstaclesIndex].transform.rotation);
        }
    }
}
