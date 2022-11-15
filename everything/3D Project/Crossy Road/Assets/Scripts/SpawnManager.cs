using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Water;
    public GameObject Grass;
    public GameObject Road;
    public GameObject Player;
    public GameObject[] SpawnObject;
    private Vector3 intPos = new Vector3(0, 0, 0);
    private int firstRand;
    private int secondRand;
    private int distancePlayer;
    private float currentPos;
    private float lastPos;

    void Awake()
    {
        lastPos = Player.transform.position.x;
    }

    void Update()
    {
        if (Input.GetButtonDown("up"))
        {
            currentPos = Player.transform.position.x;
            distancePlayer += 3;
            firstRand = Random.Range(1, 4);
            if (firstRand == 1) //grass
            {
                intPos = new Vector3(distancePlayer, -1f, 0);
                GameObject GrassIns = Instantiate(Grass) as GameObject; //add "as GameObject" to see?
                GrassIns.transform.position = intPos;
            }
            if (firstRand == 2) //water
            {
                intPos = new Vector3(distancePlayer, -1f, 0);
                GameObject WaterIns = Instantiate(Water) as GameObject; //add "as GameObject" to see?
                WaterIns.transform.position = intPos;
            }
            if (firstRand == 3) //road
            {
                intPos = new Vector3(distancePlayer, -1f, 0);
                GameObject RoadIns = Instantiate(Road) as GameObject; //add "as GameObject" to see?
                RoadIns.transform.position = intPos;
            }
            lastPos = currentPos;
        }
        else
            return ;
    }
}
