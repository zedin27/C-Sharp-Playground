using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = -8;
    private float leftBound = -2;
    private PlayerControl playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Tomato").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        if ((gameObject.CompareTag("Pipe") || gameObject.CompareTag("Particles")) && transform.position.x < leftBound)
            gameObject.SetActive(false);
    }
}
