using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 4;
    public float gravityModifier;
    public bool isOnGround = false;
    public bool gameOver = false;
    private float upperBound = 9;
    private UIManager UIManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        // UIManagerScript = GameObject.Find("Score_text").GetComponent<UIManager>();
        // .Find("Tomato").GetComponent<PlayerControl>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerRb.velocity.y < 0)
                playerRb.velocity = Vector3.zero;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
        if (transform.position.y > upperBound)
        {
            transform.position = new Vector3(transform.position.x, upperBound, transform.position.z);
            jumpForce = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Grass_floor") || collision.gameObject.CompareTag("Pipe"))
        {
            Debug.Log("Game Over!");
            gameOver = true;
        }
    }
}
