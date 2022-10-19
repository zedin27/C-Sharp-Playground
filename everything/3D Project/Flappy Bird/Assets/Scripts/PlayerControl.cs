using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRb;
    public Vector3 somedistance;
    public bool gameOver = false;
    private float upperBound = 9;
    public float my_gravity = -9.81f;
    public float upforce;
    private bool sleeping;
    private float velocity;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(7.5f, 3.5f , -10.25f);
        playerRb = GetComponent<Rigidbody>();
        playerRb.drag = 5f;
        playerRb.mass = 9001.42f;
        sleeping = false;
        upforce = 6.66f;
        // Physics.gravity *= gravityModifier;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            Time.timeScale = 0;
        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                somedistance = Vector3.up * upforce;
            somedistance.y +=  my_gravity * Time.deltaTime;
            transform.position += somedistance * Time.deltaTime;
            if (transform.position.y > upperBound)
                transform.position = new Vector3(transform.position.x, upperBound, transform.position.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grass_floor") || collision.gameObject.CompareTag("Pipe"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            upforce = 0;
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }
    // private void StartMenu()
    // {
    //     if (!gameOver && Input.GetKeyDown(KeyCode.Space))
    //     {

    //     }
    // }
}
