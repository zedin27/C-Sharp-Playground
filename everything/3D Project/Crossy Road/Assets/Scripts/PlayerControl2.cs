using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
** Camera Viewport limithttps://docs.unity3d.com/ScriptReference/Camera.WorldToViewportPoint.html
*/
public class PlayerControl2 : MonoBehaviour
{
    private bool _hasFireFirstInput = false;
    private bool _isIdle = true;

    public float lerpTime;
    public float currentLerpTime;
    public float changeRatio = 1;

    Vector3 startPos;
    Vector3 endPos;
    Rigidbody rb;
    Camera cam;
    public Transform target;
    

    public bool IsIdle => _isIdle;
    public bool HasFireFirstInput => _hasFireFirstInput;
    public bool hit = false;
    public bool isDisabled = false;
    private float upperBoundZ = 9f; //Maximum range for player to move

    //Gameover tutorial
    public bool gameOver = false;
    public bool outOfBounds;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (!gameOver)
        {
            Vector3 viewPos = cam.WorldToViewportPoint(target.position);
            if (viewPos.x <= 0.20f)
                gameOver = true;
            Init();
            MovementBehaviors();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
            HitAndDie();
        if (collision.gameObject.CompareTag("Tree")) //prevent player from moving forward
        {
            //I want to stop the player from moving forward after here
            print("I'm touching some grass ( ͡° ͜ʖ ͡°)");
        }
    }

    private void Init()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            if (changeRatio == 1)
            {
                lerpTime = 1;
                currentLerpTime = 0;
                _hasFireFirstInput = true;
                _isIdle = false;
                outOfBounds = false;

                ActiveVector3();
            }
        }
        else
            _isIdle = true;
    }
    private void MovementBehaviors()
    {
        if (Input.GetButtonDown("up"))
            endPos = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
        if (Input.GetButtonDown("down"))
            endPos = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
        if (Input.GetButtonDown("left") && !(gameObject.transform.position.z >= 9f))
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f);
        if (Input.GetButtonDown("right") && !(gameObject.transform.position.z <= -9f))
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f);
    }
    private bool ActiveVector3()
    {
        if (!outOfBounds)
        {
            Vector3 pos = transform.position;
            gameObject.transform.position = Vector3.Lerp(startPos, endPos, changeRatio);
            pos = new Vector3(pos.x, pos.y, pos.z + .3f * Time.deltaTime);
            return true;
        }
        return false;
    } 
    private void HitAndDie()
    {
        if (hit == false)
        {
            hit = true;
            GameOver();
        }
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        gameOver = true;
        print("Game Over!");
    }
}
