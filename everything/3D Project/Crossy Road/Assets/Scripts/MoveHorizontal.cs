using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontal : MonoBehaviour
{
    public float speed = 8;
    private float zBoundary = 10f;
    private PlayerControl2 playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("PlayerObject").GetComponent<PlayerControl2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        // if ((gameObject.CompareTag("Vehicle") || gameObject.CompareTag("Particles")) && transform.position.x < zBoundary)
        //     gameObject.SetActive(false);
    }
}
