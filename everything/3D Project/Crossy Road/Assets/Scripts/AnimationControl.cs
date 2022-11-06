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
    void Update()
    {
        Bounce bounceScript = thePlayer.GetComponent<Bounce>();

        if (bounceScript.justJump == true)
            animatorScript.SetBool("Jump", true);
        else
            animatorScript.SetBool("Jump", false);
    }
}
