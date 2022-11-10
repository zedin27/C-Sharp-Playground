using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
** Camera following player (Smoothing and angle): https://youtu.be/4HpC--2iowE
** Maximo: https://www.youtube.com/watch?v=bXNFxQpp2qk&ab_channel=iHeartGameDev
** Moving character relative to camera: https://forum.unity.com/threads/moving-character-relative-to-camera.383086/
** Camera follow v2: https://youtu.be/Jpqt2gRHXtc?list=PLq_nO-RwB516fNlRBce0GbtJSfysAjOgU
*/

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public PlayerControl playerControlScript;
    // public Camera mainCamera;
    private Vector3 offset;
    private Vector3 playerPositionLast;
    private Vector3 ogSpot = new Vector3(4.769f, 1.4671f, -2.532761f); //Just in case I need to reposition the camera once again (x and z are the ones that changes if player moves)
    public float distanceToMoveX;
    public float distanceToMoveZ;
    public bool stillIdle;

    void Start()
    {
        stillIdle = false;
        playerPositionLast = player.transform.position; 
        offset = transform.position - player.transform.position;
        PlayerControl playerControlScript = GetComponent<PlayerControl>();
    }

    void LateUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        var forward = Camera.main.transform.forward;
        var right = Camera.main.transform.right;
        
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        print($"forward: {forward}");
        print($"right: {right}");
        // distanceToMoveX = playerControlScript.transform.position.x - playerPositionLast.x;
        // distanceToMoveZ = playerControlScript.transform.position.z - playerPositionLast.z;
        // print("distanceToMove: " + distanceToMove);
        if (!playerControlScript.GetfirstInput()) //False
        {
            // transform.position = new Vector3(transform.position.x + distanceToMoveX, transform.position.y, transform.position.z + distanceToMoveZ);
            // playerPositionLast = playerControlScript.transform.position;
            print($"distanceToMoveX: {distanceToMoveX}\ndistanceToMoveZ:{distanceToMoveZ}");
        }
        else //True
        {
            transform.position = new Vector3(transform.position.x + 0.69f * Time.deltaTime, transform.position.y, transform.position.z); //Moving camera away effect
            print("offset: " + offset);
            // transform.position +=  * Time.deltaTime;
        }
        // transform.position = playerPositionLast + offset;
        // var desiredMovement = (forward * playerControlScript.transform.position.x) + (right * playerControlScript.transform.position.z);
        // transform.Translate(desiredMovement * 0.42f * Time.deltaTime);
        // print($"desiredMovement: {desiredMovement}");
    }
}
