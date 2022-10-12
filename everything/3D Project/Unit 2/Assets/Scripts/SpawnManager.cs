using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] humanPrefabs;
    float xRange = 10;
    float zRange = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.69f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SpawnRandomAnimal();
    }
    void SpawnRandomAnimal()
    {
        int humanIndex = Random.Range(0, humanPrefabs.Length);
        Vector3 humanPos = new Vector3(Random.Range(-xRange, xRange), 0, zRange);
        Instantiate(humanPrefabs[humanIndex], humanPos, humanPrefabs[humanIndex].transform.rotation);
    }
}
