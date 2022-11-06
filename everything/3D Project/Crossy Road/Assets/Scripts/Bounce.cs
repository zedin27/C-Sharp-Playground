using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float lerpTime;
    public float currentLerpTime;
    public float changeRatio = 1;
    bool firstInput;
    public bool justJump;

    Vector3 startPos;
    Vector3 endPos;

    void Update()
    {
        if (Input.GetButtonDown("up") || Input.GetButtonDown("left") || Input.GetButtonDown("right") || Input.GetButtonDown("down"))
        {
            if (changeRatio == 1)
            {
                lerpTime = 1;
                currentLerpTime = 0;
                firstInput = true;
                justJump = true;
            }
        }
        startPos = gameObject.transform.position;
        //REVIEW: convert this if-conditions to a switch case or something else than repetiveness
        if (Input.GetButtonDown("up") && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
        if (Input.GetButtonDown("down") && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }
        if (Input.GetButtonDown("left") && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        }
        if (Input.GetButtonDown("right") && gameObject.transform.position == endPos)
        {
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        }
        if (firstInput == true)
        {
            currentLerpTime += Time.deltaTime * 4.2f;
            changeRatio = currentLerpTime / lerpTime;
            gameObject.transform.position = Vector3.Lerp(startPos, endPos, changeRatio);
            if (changeRatio > 0.8f)
                changeRatio = 1;
            if (Mathf.Round(changeRatio) == 1)
                justJump = false;
        }
    }
}
