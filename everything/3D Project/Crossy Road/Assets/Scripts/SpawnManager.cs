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
    // public Spawn[] Field;
    public Spawn[] Field2;
    public GameObject[] SpawnObjectTrees; //Trees
    public GameObject[] SpawnObjectVehicles; //different vehicles
    public GameObject[] SpawnObjectPlanks; //3 sizes
    private PlayerControl2 playerControlScript;
    private Vector3 intPos = new Vector3(0, 0, 0);
    private int firstRand;
    private int secondRand;
    private int distancePlayer;
    private float currentPos;
    private float lastPos;

    [SerializeField] private float startDelay = 1.69f;
    [SerializeField] private float repeatRate = 1.1f;

    void Awake()
    {
        lastPos = Player.transform.position.x;
        playerControlScript = GameObject.Find("PlayerObject").GetComponent<PlayerControl2>();
        // InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void Update()
    {
        if (Input.GetButtonDown("up"))
        {
            distancePlayer += 3;
            SpawnField();
        }
        // if (Input.GetButtonDown("up"))
        // {
        //     currentPos = Player.transform.position.x;
        //     distancePlayer += 3;
        //     firstRand = Random.Range(1, 4); //superficial random weight. Can be improved
        //     if (firstRand == 1) //grass (here is where I want to setActive false/true randomly)
        //     {
        //         intPos = new Vector3(distancePlayer, -1f, 0);
        //         GameObject GrassIns = Instantiate(Field[firstRand]) as GameObject; //add "as GameObject" to see?
        //         GrassIns.transform.position = intPos;
        //     }
        //     if (firstRand == 2) //water
        //     {
        //         intPos = new Vector3(distancePlayer, -1f, 0);
        //         GameObject WaterIns = Instantiate(Field[firstRand]) as GameObject; //add "as GameObject" to see?
        //         WaterIns.transform.position = intPos;
        //     }
        //     if (firstRand == 3) //road
        //     {
        //         intPos = new Vector3(distancePlayer, -1f, 0);
        //         GameObject RoadIns = Instantiate(Field[firstRand]) as GameObject; //add "as GameObject" to see?
        //         RoadIns.transform.position = intPos;
        //     }
        //     lastPos = currentPos;
        // }
        // else
        //     return ;
    }
    void SpawnField()
    {
        //I want to spawn the vehicles, planks, and trees in sets accordingly to the field (grass, river, road)
        //For vehicles and planks, they can move horizontally from either -z or z boundaries
        int i = Random.Range(0, 100);
        for(int j = 0; j < Field2.Length; j++)
        {
            if (i >= Field2[j].minProbabilityRange && i <= Field2[j].maxProbabilityRange)
            {
                // if (j == 1)
                //     Instantiate(Field2[1].spawnField, transform.position, transform.rotation);
                intPos = new Vector3(distancePlayer, -1f, 0);
                Instantiate(Field2[j].spawnField, transform.position, transform.rotation); //FIXME: Getting close here, I need to add somehow the intPos and create it as a new GameObject through another class
                transform.position = intPos;
                // Instantiate(Field2[j].spawnField, transform.position, transform.rotation);
                break ;
            }
        }
    }
}

[System.Serializable]
public class Spawn
{
    public GameObject spawnField;
    public float minProbabilityRange = 0.0f;
    public float maxProbabilityRange = 0.0f;
}