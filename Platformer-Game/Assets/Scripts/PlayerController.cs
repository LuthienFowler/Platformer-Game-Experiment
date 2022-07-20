using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Variables
    public float speed = 10f;
    public float jumpForce = 10f;
    private Rigidbody2D playerRb;
    public bool isOnGround = false;
    public float hi;
    public int coinCount = 0;
    public bool isDead = false;
    public bool gameWon = false;

    // Bounds
    public float xBoundLeft = -3f;
    public float xBoundRight = 0f;
    private float yBoundBottom = -5f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Die();

    }

    // Moving the player
    void Move()
    {
        hi = Input.GetAxis("Horizontal");

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
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }
    }

    // Destroying the player if the player falls
    void Die()
    {
        if (!gameWon)
        {
            if (transform.position.y < yBoundBottom)
            {
                Destroy(gameObject);
                isDead = true;
            }
            else
            {
                Move();
                Jump();
            }
        }
    }

    // Checking if the player collided with anything 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("coin"))
        {
            coinCount++;

            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("end"))
        {
            Destroy(gameObject);
            gameWon = true;
        }
    }
}
