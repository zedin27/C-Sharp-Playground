using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
** Weighted randomness: https://forum.unity.com/threads/random-numbers-with-a-weighted-chance.442190/
** Scriptable Object Weight spawn example: https://www.youtube.com/watch?v=FCksj9ofUgI&ab_channel=LlamAcademy
** From scratch loot tables with Scriptable Objects to make a loot table: https://www.youtube.com/watch?v=tX3RWsVLnzM&ab_channel=GregDevStuff
** Creating a random with an animation curve: https://www.youtube.com/watch?v=zw1OERK5xvU&ab_channel=HamzaHerbou
** Random Vehicle position spawn (maybe this can help me): https://stackoverflow.com/questions/51312481/move-spawn-object-to-random-position
** TODO: Prefab shit has to be unpacked and used only once, not having multiple vehicles(n)
** 
*/

public class SpawnManager : MonoBehaviour
{
    public GameObject Player;
    public Spawn[] Field;
    public GameObject[] SpawnObjectTrees;
    public GameObject[] SpawnObjectVehicles; //different vehicles
    public GameObject[] SpawnObjectPlanks; //3 sizes (small, medium, large)
    public GameObject TryingOutThisVehicleSpawn;
    private Vector3 initialObjectSpawn;
    private PlayerControl2 playerControlScript;
    private int distancePlayer;
    private int toggle;
    private bool keepSpawning;
    bool vehicleFlag = false;
    bool plankFlag = false;
    private float currentPos;
    private float lastPos;
    public float randomNumSpawn;

    void Awake()
    {
        keepSpawning = true;
        initialObjectSpawn = transform.position;
        lastPos = Player.transform.position.x;
        playerControlScript = GameObject.Find("PlayerObject").GetComponent<PlayerControl2>();
        InvokeRepeating("Spawner", 3f, randomNumSpawn);
    }

    void Update()
    {
        if (Input.GetButtonDown("up") && !playerControlScript.gameOver)
            SpawnField();
    }

    void Spawner() //These are used for the planks and vehicles (still not attached to the objects yet)
    {
        bool activeLeft = false;
        bool activeRight = false;

        if (vehicleFlag)
        {
            print(initialObjectSpawn);
            for (int i = 0; i < SpawnObjectVehicles.Length; i++)
            {
                print($"{SpawnObjectVehicles[i]}: {SpawnObjectVehicles[i].transform.position}");
                toggle = Random.Range(0, 2);
                if (toggle == 1 && !activeLeft)
                {
                    activeLeft = true;
                    SpawnObjectVehicles[i].SetActive(true);
                    // if (SpawnObjectVehicles[i].transform.position.z >= 1.8f)
                    //     print("gtfo from left");
                }
                if (toggle == 0 && !activeRight)
                {
                    activeRight = true;
                    SpawnObjectVehicles[i].SetActive(true);
                    // if (SpawnObjectVehicles[i].transform.position.z >= 1.8f)
                    //     print("reset my position from right");
                }
                else
                    SpawnObjectVehicles[i].SetActive(false);
            }
        }
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
                    if (Surface.CompareTag("Road"))
                    {
                        vehicleFlag = true;
                        VehicleToggle();
                    }
                    // if (Surface.CompareTag("River"))
                    // {
                    //     plankFlag = true;
                    //     PlankToggle();
                    // }
                    //Add spawn for vehicles and planks with given spawnrate/spawn intervals
                    Surface.transform.position = intPos;
                    vehicleFlag = false;
                    plankFlag = false;
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
        Spawner();
    }
    
    void PlankToggle()
    {
        Spawner();
    }
}

[System.Serializable]
public class Spawn
{
    public GameObject spawnField;
    public float minProbabilityRange = 0.0f;
    public float maxProbabilityRange = 0.0f;
}