using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpHeight = 5.0f;
    public float moveSpeed = 5.0f;
    public bool isAirborne = false;
    private bool isDoubleJumping = false;
    private Rigidbody2D rb2d;
    private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb2d.gravityScale));
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = 0.0f;

        if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1.0f;
        }

        // Sets the velocity of the player rigidbody to moveHorizontal times their move speed
        rb2d.velocity = new Vector2(moveHorizontal * moveSpeed, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isAirborne)
            {
                // Initial jump
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isAirborne = true;
            }
            else if (!isDoubleJumping)
            {
                // Double jump
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0); // Resets the player's vertical velocity before a jump
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isDoubleJumping = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isAirborne = false;
            isDoubleJumping = false;
        }
    }

 
}