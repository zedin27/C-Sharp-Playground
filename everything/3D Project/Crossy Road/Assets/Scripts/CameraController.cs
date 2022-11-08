using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(4.769f, 1.4671f, -2.532761f);
    void Start()
    {
        
    }

    void LateUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position + offset;
        
    }
    // void Update()
    // {

    // }
}
