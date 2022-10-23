// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// /*
// ** Rotation boundaries: https://stackoverflow.com/questions/71905959/how-to-limit-rotation-of-object-in-unity
// */


// public class PlayerControl : MonoBehaviour
// {
//     private Rigidbody playerRb;
//     public Vector3 movementDirection;
//     public AudioSource sound_flap;
//     public AudioSource sound_hit;
//     public AudioSource sound_die;
//     private Vector3 currentEuler;
//     public bool gameOver = false;
//     private float upperBound = 9;
//     private float backBound = -90.0f;
//     public float my_gravity = -9.81f;
//     public float fallSpeed = 0;
//     public float upforce;
//     private bool sleeping;
//     private float velocity;

//     // Start is called before the first frame update
//     void Start()
//     {
//         transform.position = new Vector3(10.75f, 3.5f , -10.25f);
//         playerRb = GetComponent<Rigidbody>();
//         playerRb.drag = 5f;
//         playerRb.mass = 9001.42f;
//         sleeping = true;
//         upforce = 6.66f;
//         Time.timeScale = 0;
//         currentEuler = transform.eulerAngles;
//     }
//     // Update is called once per frame
//     void Update()
//     {
//         StartSpawn();
//         if (!gameOver)
//         {
//             // FallSpeed();
//             PlayersAction();
//             if (transform.position.y > upperBound)
//                 transform.position = new Vector3(transform.position.x, upperBound, transform.position.z);
//         }
//     }
//     private void OnCollisionEnter(Collision collision)
//     {
//         if (collision.gameObject.CompareTag("Grass_floor") || collision.gameObject.CompareTag("Pipe"))
//             GameOver();
//     }
//     private void StartSpawn()
//     {
//         if (sleeping && Input.GetKeyDown(KeyCode.Space))
//         {
//             Time.timeScale = 1;
//             sleeping = !sleeping;
//         }
//     }
//     private void FallSpeed()
//     {
//         fallSpeed += 0.24f * Time.deltaTime;
//         transform.Rotate(Vector3.back * fallSpeed);
//         if (transform.rotation.z <= backBound || transform.rotation.z >= 0)
//         {
//             print("Hi");
//             transform.rotation = Quaternion.FromToRotation(transform.forward, Vector3.up);
//         }
//     }
//     private void Replay()
//     {
//         gameOver = false;
//     }

//     private void GameOver()
//     {
//             sound_hit.Play();
//             sound_die.Play();
//             transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
//             upforce = 0;
//             gameOver = true;
//             Time.timeScale = 0;
//             Debug.Log("Game Over!");
//     }

//     private void PlayersAction()
//     {
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             fallSpeed = 0;
//             sound_flap.Play();
//             movementDirection = Vector3.up * upforce;
//         }
//         movementDirection.y +=  my_gravity * Time.deltaTime;
//         transform.position += movementDirection * Time.deltaTime;
//         Debug.Log(transform.eulerAngles.z);
//         if (transform.eulerAngles.z > 270.0f && transform.eulerAngles.z <= 358.0f)
//         {
//             Vector3 currentEuler = transform.eulerAngles;
//             currentEuler.z = 4 * movementDirection.y;
//             transform.eulerAngles = currentEuler;
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
** Rotation boundaries: https://stackoverflow.com/questions/71905959/how-to-limit-rotation-of-object-in-unity
*/


public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRb;
    public Vector3 velocity;
    public AudioSource sound_flap;
    public AudioSource sound_hit;
    public AudioSource sound_die;
    private Vector3 currentEuler;
    public bool gameOver = false;
    private float upperBound = 9;
    public float my_gravity = -9.81f;
    public float fallSpeed = 0;
    public float upforce;
    private bool sleeping;
    private float minAngle = -69.0f;
    private float maxAngle = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(10.75f, 3.5f , -10.25f);
        playerRb = GetComponent<Rigidbody>();
        playerRb.drag = 5f;
        playerRb.mass = 9001.42f;
        sleeping = true;
        upforce = 6.66f;
        Time.timeScale = 0;
    }
    // Update is called once per frame
    void Update()
    {
        StartSpawn();
        if (!gameOver)
        {
            FallSpeedAngle();
            PlayersAction();
            if (transform.position.y > upperBound)
                transform.position = new Vector3(transform.position.x, upperBound, transform.position.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grass_floor") || collision.gameObject.CompareTag("Pipe"))
            GameOver();
    }
    private void StartSpawn()
    {
        if (sleeping && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            sleeping = !sleeping;
        }
    }
    private void FallSpeedAngle()
    {
        // remove below for later just in case
        // velocity.y += 0.24f * Time.deltaTime;
        // transform.position += velocity * Time.deltaTime;
        
        float newAngle = Mathf.Atan2(velocity.y, 1);
        newAngle = Mathf.Clamp(newAngle * Mathf.Rad2Deg, minAngle, maxAngle);
        transform.localEulerAngles = new Vector3(0, 0, newAngle + 21.007f); //FIXME: Find a better solution and replace the hardcoded value.
    }
    private void Replay()
    {
        gameOver = false;
    }

    private void GameOver()
    {
            sound_hit.Play();
            sound_die.Play();
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            upforce = 0;
            gameOver = true;
            Time.timeScale = 0;
            Debug.Log("Game Over!");
    }

    private void PlayersAction()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fallSpeed = 0;
            sound_flap.Play();
            velocity = Vector3.up * upforce;
        }
        velocity.y +=  my_gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
}