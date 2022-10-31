using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclesPrefab;
    private PlayerControl playerControllerScript;
    // public RayCastDetection rayCastDetectionScript;
    private float startDelay = 1.69f;
    private float repeatRate = 1.1f;
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
        // int obstaclesIndex = Random.Range(0, obstaclesPrefab.Length);
        
        if (playerControllerScript.gameOver == false)
        {
            float randomY = Random.Range(-2f, 2f);
            Vector3 randomHeight = new Vector3(35, randomY, -7);
            GameObject pipe = ObjectPooling.sharedInstance.GetPooledObject();
            if (pipe != null)
            {
                pipe.transform.position = randomHeight;
                pipe.SetActive(true);
                // rayCastDetectionScript.passed = false;
            }
        }
            // Instantiate(obstaclesPrefab[obstaclesIndex], randomHeight, obstaclesPrefab[obstaclesIndex].transform.rotation);
    }
}
