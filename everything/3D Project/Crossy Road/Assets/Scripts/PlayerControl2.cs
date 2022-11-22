using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
** Camera Viewport limit: https://docs.unity3d.com/ScriptReference/Camera.WorldToViewportPoint.html
** CrossPlatform InputManager: https://medium.com/nerd-for-tech/cross-platform-input-in-unity-db165de74a29
*/
public class PlayerControl2 : MonoBehaviour
{
    private bool _hasFireFirstInput = false;
    private bool _isIdle = true;
    public bool IsIdle => _isIdle;
    public bool HasFireFirstInput => _hasFireFirstInput;

    public float lerpTime;
    public float currentLerpTime;
    public float changeRatio = 1.0f;

    public Transform target;
    Vector3 startPos;
    Vector3 endPos;
    Rigidbody rb;
    Camera cam;

    public bool justJump;
    public bool hit = false;
    public bool gameOver = false;
    public bool outOfBounds;
    private float fixedDeltaTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        // this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    private void Update()
    {
        if (!gameOver)
        {
            Init();
            CameraOutOfRange();
            MovementBehaviors();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
            HitAndDie();
        //I want to stop the player from moving forward after here
        if (collision.gameObject.CompareTag("Tree")) //prevent player from moving forward
        {
            // ActiveVector3();
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
                justJump = true;

                ActiveVector3();
            }
        }
        else
            _isIdle = true;
    }
    private void MovementBehaviors()
    {
        // PauseMenu();
        if (Input.GetButtonDown("up"))
            endPos = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
        if (Input.GetButtonDown("down"))
            endPos = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
        if (Input.GetButtonDown("left") && !(gameObject.transform.position.z >= 9f))
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f);
        if (Input.GetButtonDown("right") && !(gameObject.transform.position.z <= -9f))
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f);
        if (HasFireFirstInput)
        {
            currentLerpTime += Time.deltaTime * 4.2f;
            changeRatio = currentLerpTime / lerpTime;
            gameObject.transform.position = Vector3.Lerp(startPos, endPos, 1);
            if (changeRatio > 0.8f)
                changeRatio = 1;
            if (Mathf.Round(changeRatio) == 1)
            {
                currentLerpTime = 1.0f;
                justJump = false;
            }
        }
    }
    private bool ActiveVector3()
    {
        if (!outOfBounds)
        {
            print(transform.position);
            Vector3 pos = transform.position;
            print(pos);
            gameObject.transform.position = Vector3.Lerp(startPos, endPos, changeRatio);
            pos = new Vector3(pos.x, pos.y, pos.z + .3f * Time.deltaTime);
            return true;
        }
        return false;
    } 
    private void HitAndDie()
    {
        if (!hit)
        {
            hit = true;
            GameOver();
        }
        Time.timeScale = 1;
    }

    private void CameraOutOfRange()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(target.position);
        if (viewPos.x <= 0.20f)
            GameOver();
    }

    //FIXME
    // public void PauseMenu()
    // {
    //     if (Input.GetKeyDown(KeyCode.P) && !gameOver)
    //         Time.timeScale = 0;
    //     else
    //         Time.timeScale = 1;
    //     Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        
    // }

    public void GameOver()
    {
        gameOver = true;
        print("Game Over!");
    }
}
