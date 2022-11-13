using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
** CrossPlatform InputManager: https://medium.com/nerd-for-tech/cross-platform-input-in-unity-db165de74a29
*/

public class PlayerControl : MonoBehaviour
{
    public float lerpTime;
    public float currentLerpTime;
    public float changeRatio = 1;
    bool firstInput;
    private float horizontalMove; //Unused atm
    private float verticalMove; //Unused atm
    public bool justJump;
    public bool moved;
    int zRange = 11;
    Vector3 startPos;
    Vector3 endPos;

    public bool GetfirstInput()
    {
        return firstInput;
    }
    void Start()
    {
        if (MasterSingleton.main != null)
            MasterSingleton.main.printSomething();
        return ;
    }

    void Update()
    {
        // horizontalMove = Input.GetAxis("Horizontal"); // d key changes value to 1, a key changes value to -1
        // verticalMove = Input.GetAxis("Vertical"); // w key changes value to 1, s key changes value to -1
        // Vector3 movement = new Vector3(horizontalMove, 0, verticalMove);

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
            moved = true;
            currentLerpTime += Time.deltaTime * 4.2f;
            changeRatio = currentLerpTime / lerpTime;
            gameObject.transform.position = Vector3.Lerp(startPos, endPos, changeRatio);
            if (changeRatio > 0.8f)
                changeRatio = 1;
            if (Mathf.Round(changeRatio) == 1)
                justJump = false;
            // firstInput = false;
        }
    }
}
