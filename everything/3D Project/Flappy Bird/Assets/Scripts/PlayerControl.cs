using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
** Rotation boundaries: https://stackoverflow.com/questions/71905959/how-to-limit-rotation-of-object-in-unity
** Aspect Ratio fitter: https://stackoverflow.com/a/55512751/6017248
** Flashing when getting hit by colission: https://www.youtube.com/watch?v=d9FaI28Yf9A&ab_channel=Firemind
*/


public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRb;
    public Vector3 velocity;
    public AudioSource sound_flap;
    public AudioSource sound_hit;
    public AudioSource sound_die;
    private Vector3 currentEuler;
    public Transform target; // "grass_floor"
    private CanvasGroup canvas;
    public GameObject gotHitScreen;
    // public ParticleSystem particles;
    public bool gameOver = false;
    public bool passedBeam = false;
    private bool tutorial = false;
    private float upperBound = 9f;
    public float my_gravity = -9.81f;
    private float minAngle = -69.0f;
    private float maxAngle = 12.0f;
    public bool hit;
    public float upforce;
    private bool sleeping;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(10.75f, 3.5f , -10.25f);
        canvas = GameObject.Find("Text").GetComponent<CanvasGroup>();
        playerRb = GetComponent<Rigidbody>();
        // particles = GameObject.Find("Particles").GetComponent<ParticleSystem>();
        // particles.Stop();
        playerRb.drag = 5f;
        playerRb.mass = 9001.42f;
        sleeping = true;
        hit = false;
        upforce = 6.66f;
        Time.timeScale = 0;
    }
    // Update is called once per frame
    void Update()
    {
        StartSpawn();
        if (!gameOver)
        {
            HideTutorial();
            FallSpeedAngle();
            PlayersAction();
            if (transform.position.y > upperBound)
                transform.position = new Vector3(transform.position.x, upperBound, transform.position.z);
        }
        else
        {
            if (transform.position.y >= target.position.y)
            {
                velocity.y +=  my_gravity * Time.deltaTime;
                transform.position += velocity * Time.deltaTime;
                FallSpeedAngle();
            }
            //Add here the hitscreen maybe, right before gameover
            GameOver();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grass_floor") || collision.gameObject.CompareTag("Pipe"))
        {
            HitAndDie();
            GameOver();
        }
    }
    private void StartSpawn()
    {
        if (sleeping && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)))
        {
            tutorial = true;
            HideTutorial();
            Time.timeScale = 1;
            sleeping = !sleeping;
        }
    }

    private void HideTutorial()
    {
        if (canvas.CompareTag("Text") && tutorial == true)
            canvas.alpha = 0;
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
        if (hit == false)
        {
            var color = gotHitScreen.GetComponent<Image>().color;
            color.a = 0.6f;

            gotHitScreen.GetComponent<Image>().color = color;
            hit = true;
            sound_hit.Play();
            sound_die.Play();
            // particles.Stop();
            print("Game Over!");
        }
        Time.timeScale = 1;
    }
    private void GameOver()
    {
        if (gotHitScreen != null)
        {
            if (gotHitScreen.GetComponent<Image>().color.a > 0)
            {
                var color = gotHitScreen.GetComponent<Image>().color;
                color.a -= 0.042f;

                gotHitScreen.GetComponent<Image>().color = color;
            }
        }
        gameOver = true;
    }

    private void PlayersAction()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            sound_flap.Play();
            velocity = Vector3.up * upforce;
        }
        velocity.y +=  my_gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }
}