using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Water;
    public GameObject Grass;
    public GameObject Road;

    private Vector3 intPos = new Vector3(0, 0, 0);
    private int firstRand;
    private int secondRand;
    private int distancePlayer;

    void Update()
    {
        if (Input.GetButtonDown("up"))
        {
            firstRand = Random.Range(1, 4);
            if (firstRand == 1)
            {
                secondRand = Random.Range(1, 8);
                for (int i = 0; i < secondRand; i++)
                {
                    intPos = new Vector3(0, 0, distancePlayer);
                    distancePlayer++;
                    
                }
            }
        }
    }
}
