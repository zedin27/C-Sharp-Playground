using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
** Weighted randomness: https://forum.unity.com/threads/random-numbers-with-a-weighted-chance.442190/
** Scriptable Object Weight spawn example: https://www.youtube.com/watch?v=FCksj9ofUgI&ab_channel=LlamAcademy
** From scratch loot tables with Scriptable Objects to make a loot table: https://www.youtube.com/watch?v=tX3RWsVLnzM&ab_channel=GregDevStuff
** Creating a random with an animation curve: https://www.youtube.com/watch?v=zw1OERK5xvU&ab_channel=HamzaHerbou
** 
** 
*/

public class SpawnManager : MonoBehaviour
{
    public GameObject Player;
    public Spawn[] Field;
    public GameObject[] SpawnObjectTrees;
    public GameObject[] SpawnObjectVehicles; //different vehicles
    public GameObject[] SpawnObjectPlanks; //3 sizes (small, medium, large)
    private PlayerControl2 playerControlScript;
    private int firstRand;
    private int secondRand;
    private int distancePlayer;
    private bool keepSpawning;
    private float currentPos;
    private float lastPos;

    void Awake()
    {
        keepSpawning = true;
        lastPos = Player.transform.position.x;
        playerControlScript = GameObject.Find("PlayerObject").GetComponent<PlayerControl2>();
        Invoke("RandomIntervalRateSpawn", 0.5f); //make random interval between two float values with a constant delay (or vice-versa)
    }

    void Update()
    {
        if (Input.GetButtonDown("up") && !playerControlScript.gameOver)
            SpawnField();
    }

    void RandomIntervalRateSpawn() //These are used for the planks and vehicles (still not attached to the objects yet)
    {
        float randomNum = Random.Range(3.69f, 4.2f);
        float speed = Random.Range(4.0f, 9.69f);
        Invoke("RandomIntervalRateSpawn", randomNum);
        print(randomNum);
    }

    void SpawnField()
    {
        //I want to spawn the vehicles, planks, and trees in sets accordingly to the field (grass, river, road)
        //For vehicles and planks, they can move horizontally from either -z or z boundaries
        //NOTE: keepSpawning may be useless if i have a playerControlScript.gameOver already in here
        if (keepSpawning)
        {
            distancePlayer += 3;
            Vector3 intPos = new Vector3(0, 0, 0);
            int i = Random.Range(0, 1000);
            for (int j = 0; j < Field.Length; j++)
            {
                if (i >= Field[j].minProbabilityRange && i <= Field[j].maxProbabilityRange)
                {
                    intPos = new Vector3(distancePlayer, -1f, 0);
                    GameObject Surface = Instantiate(Field[j].spawnField);
                    if (Surface.CompareTag("Grass"))
                        TreeToggle();
                    //Add spawn for vehicles and planks with given spawnrate/spawn intervals
                    Surface.transform.position = intPos;
                }
            }
        }
    }
    void TreeToggle()
    {
        int counter = 0;
        for (int i = 0; i < SpawnObjectTrees.Length; i++)
        {
            int toggle = Random.Range(0, 2); //[0, 2)
            if (toggle == 1 && counter < 5) //True and when there are already 5-4 trees to toggle
            {
                counter++;
                SpawnObjectTrees[i].SetActive(true);
            }
            else //fills the rest to inactive Trees
                SpawnObjectTrees[i].SetActive(false);
        }
    }
    void VehicleToggle()
    {
        // I have Left and Right with 2 vehicles in each. My goal is to setActive one of them each side at a time with a different interval spawnrate and speed
        RandomIntervalRateSpawn();
        
    }
    
    void PlankToggle()
    {
        RandomIntervalRateSpawn();
    }
}

[System.Serializable]
public class Spawn
{
    public GameObject spawnField;
    public float minProbabilityRange = 0.0f;
    public float maxProbabilityRange = 0.0f;
}