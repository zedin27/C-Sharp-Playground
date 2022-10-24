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
    public bool hit = false;
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
        {
            HitAndDie();
            // GameOver();
        }
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
        float newAngle = Mathf.Atan2(velocity.y, 1);
        newAngle = Mathf.Clamp(newAngle * Mathf.Rad2Deg, minAngle, maxAngle);
        transform.localEulerAngles = new Vector3(0, 0, newAngle + 21.007f); //FIXME: Find a better solution and replace the hardcoded value.
    }
    private void Replay()
    {
        gameOver = false;
    }

    private void HitAndDie()
    {
        // transform.position += velocity * Time.deltaTime;
        // float fallPosition = Mathf.MoveTowards(transform.position.y, 0.0f, 3.0f);
        hit = true;
        float fallPosition = Mathf.Clamp(transform.position.y, 0.0f, 0.001f);
        sound_hit.Play();
        sound_die.Play();
        velocity.y +=  my_gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        transform.localPosition = new Vector3(transform.position.x, velocity.y, transform.position.z);
        // Time.timeScale = 1;
    }
    private void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over!");

        // velocity = Vector3.down * upforce;
        // velocity.y -=  my_gravity * Time.deltaTime;
        // transform.position -= velocity * Time.deltaTime;
        // // transform.position += velocity * Time.deltaTime;
        // // float fallPosition = Mathf.MoveTowards(transform.position.y, 0.0f, 1.0f);
        // sound_hit.Play();
        // sound_die.Play();
        // // transform.eulerAngles = new Vector3(transform.position.x, fallPosition, transform.position.z);
        // transform.position = Vector3.Lerp(transform.position, Vector3.down, 1);
        // // upforce = 0;
        // gameOver = true;
        // Time.timeScale = 1;
        // Debug.Log("Game Over!");
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