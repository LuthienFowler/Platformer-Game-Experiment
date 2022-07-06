using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    public float speed = 10f;
    public float jumpForce = 10f;
    private Rigidbody2D playerRb;
    public bool isOnGround = false;

    // Bounds
    private float xBoundLeft = -8.5f;
    private float xBoundRight = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    // Moving the player
    void Move()
    {
        float hi = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * hi * speed * Time.deltaTime);

        if (transform.position.x < xBoundLeft)
        {
            transform.position = new Vector3(xBoundLeft, transform.position.y, transform.position.z);
        } else if (transform.position.x > xBoundRight)
        {
            transform.position = new Vector3(xBoundRight, transform.position.y, transform.position.z);
        }
    }

    // Making the player jump 
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
