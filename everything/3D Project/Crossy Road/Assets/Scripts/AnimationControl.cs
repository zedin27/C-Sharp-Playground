using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    Animator animatorScript;
    public GameObject thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        animatorScript = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame

    void handleAnimation()
    {
        bool isIdle = animatorScript.GetBool("Idle");
        bool isMoving = animatorScript.GetBool("Jump");
    }
    void Update()
    {
        PlayerControl playerControlScript = thePlayer.GetComponent<PlayerControl>();

        if (playerControlScript.justJump == true)
            animatorScript.SetBool("Jump", true);
        else
            animatorScript.SetBool("Jump", false);
        if (Input.GetButtonDown("right"))
            gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        if (Input.GetButtonDown("left"))
            gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        if (Input.GetButtonDown("up"))
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetButtonDown("down"))
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
