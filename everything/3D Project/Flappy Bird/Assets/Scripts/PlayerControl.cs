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
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        jumpForce = 4;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
