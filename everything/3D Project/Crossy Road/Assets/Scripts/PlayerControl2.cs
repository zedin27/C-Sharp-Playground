using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl2 : MonoBehaviour
{
    private bool _hasFireFirstInput = false;
    private bool _isIdle = true;

    public float lerpTime;
    public float currentLerpTime;
    public float changeRatio = 1;

    Vector3 startPos;
    Vector3 endPos;

    public bool IsIdle => _isIdle;
    public bool HasFireFirstInput => _hasFireFirstInput;
    public bool gameOver = false;
    public bool hit = false;
    public bool isDisabled = false;
    private void Update()
    {
        if (!gameOver && !hit)
        {
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                if (changeRatio == 1)
                {
                    lerpTime = 1;
                    currentLerpTime = 0;
                    _hasFireFirstInput = true;
                    _isIdle = false;

                    Vector3 pos = transform.position;
                    gameObject.transform.position = Vector3.Lerp(startPos, endPos, changeRatio);
                    pos = new Vector3(pos.x, pos.y, pos.z + .3f * Time.deltaTime);
                }
            }
            else
                _isIdle = true;
            if (Input.GetButtonDown("up") && gameObject.transform.position == endPos)
            {
                endPos = transform.position;
                endPos = new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z);
            }
            if (Input.GetButtonDown("down") && gameObject.transform.position == endPos)
            {
                endPos = transform.position;
                endPos = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
            }
            if (Input.GetButtonDown("left") && gameObject.transform.position == endPos)
            {
                endPos = transform.position;
                endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f);
            }
            if (Input.GetButtonDown("right") && gameObject.transform.position == endPos)
            {
                endPos = transform.position;
                endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f);
            }
        }
        else
            hit = !hit;
    }

    // void OnCollisionStay(Collision collision)
    // {
    //     foreach (ContactPoint contact in collision.contacts)
    //         Debug.DrawRay(contact.point, contact.normal * 10, Color.white);
    // }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            HitAndDie();
            GameOver();
        }
    }
        private void HitAndDie()
    {
        if (hit == false)
        {
            hit = true;
            print("Game Over!");
        }
        Time.timeScale = 1;
    }
    private void GameOver()
    {
        gameOver = true;
    }
}
