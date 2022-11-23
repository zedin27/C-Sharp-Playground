using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontal : MonoBehaviour
{
    public float speed;
    public float randomNumSpawn;
    private PlayerControl2 playerControllerScript;
    void Start()
    {
        speed = Random.Range(4.0f, 9.69f);
        randomNumSpawn = Random.Range(3.69f, 4.2f);
        playerControllerScript = GameObject.Find("PlayerObject").GetComponent<PlayerControl2>();
    }
    void Update()
    {
        if (playerControllerScript.gameOver == false)
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        // if ((gameObject.CompareTag("Vehicle") || gameObject.CompareTag("Particles")) && transform.position.x < zBoundary)
        //     gameObject.SetActive(false);
    }
}
