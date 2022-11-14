using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Water;
    public GameObject Grass;
    public GameObject Road;
    public GameObject[] SpawnObject;
    private Vector3 intPos = new Vector3(0, -0.5f, 0);
    private int firstRand;
    private int secondRand;
    private int distancePlayer;

    void Update()
    {
        if (Input.GetButtonDown("up"))
        {
            distancePlayer += 3;
            firstRand = Random.Range(1, 4);
            print(intPos.x);
            if (firstRand == 1 && intPos.x != distancePlayer) //grass
            {
                    intPos = new Vector3(distancePlayer, -1f, 0);
                    GameObject GrassIns = Instantiate(Grass) as GameObject; //add "as GameObject" to see?
                    GrassIns.transform.position = intPos;
            }
            if (firstRand == 2 && intPos.x != distancePlayer) //water
            {
                    intPos = new Vector3(distancePlayer, -1f, 0);
                    GameObject WaterIns = Instantiate(Water) as GameObject; //add "as GameObject" to see?
                    WaterIns.transform.position = intPos;
            }
            if (firstRand == 3 && intPos.x != distancePlayer) //road
            {
                    intPos = new Vector3(distancePlayer, -1f, 0);
                    GameObject RoadIns = Instantiate(Road) as GameObject; //add "as GameObject" to see?
                    RoadIns.transform.position = intPos;
            }
        }
    }
}
