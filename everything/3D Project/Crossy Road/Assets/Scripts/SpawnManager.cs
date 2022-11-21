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
            SpawnField();
    }
    void SpawnField()
    {
        //I want to spawn the vehicles, planks, and trees in sets accordingly to the field (grass, river, road)
        //For vehicles and planks, they can move horizontally from either -z or z boundaries
        distancePlayer += 3;
        int i = Random.Range(0, 1000);
        for (int j = 0; j < Field.Length; j++)
        {
            if (i >= Field[j].minProbabilityRange && i <= Field[j].maxProbabilityRange)
            {
                intPos = new Vector3(distancePlayer, -1f, 0);
                GameObject Surface = Instantiate(Field[j].spawnField);
                Surface.transform.position = intPos;
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