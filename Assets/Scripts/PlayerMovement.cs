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
    public GameObject bullet;
    public Transform shootPoint;
    
    public int playerDirection = 1;
    private float shootPosition;
    public int lives;
    public AudioSource playerAudioSource;
    public Transform lastCheckpoint;
    public AudioClip [] jumpClipArray;
    public AudioClip[] dJumpClipArray;
    public AudioClip[] deathClipArray;
    public AudioClip [] respawnClipArray;
    public AudioClip victory;
    public AudioClip defeatEnemy;
    public AudioClip shoot;
    public AudioClip gameOverClip;
    private SpriteRenderer playerSprite;
    public Sprite normalSprite;
    public Sprite jumpSprite;
    private Transform playerRotation;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb2d.gravityScale));
        playerAudioSource = GetComponent<AudioSource>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerRotation = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = 0.0f;

        if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1.0f;
            playerDirection = 1;
            playerRotation.rotation = Quaternion.Euler(0, 180, 0);



        }
        if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1.0f;
            playerDirection = 0;
            playerRotation.rotation = Quaternion.Euler(0,0,0);
            
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Shoot();
        }

        // Sets the velocity of the player rigidbody to moveHorizontal times their move speed
        rb2d.velocity = new Vector2(moveHorizontal * moveSpeed, rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isAirborne)
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isAirborne = true;
                playerSprite.sprite = jumpSprite;
            }
            else if (!isDoubleJumping)
            {
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
            playerSprite.sprite = normalSprite;
        }
    }
    private void Shoot()
    {

        shootPosition = shootPoint.transform.position.x;
        GameObject newProjectile = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody2D bulletRb = newProjectile.GetComponent<Rigidbody2D>();
            
            

        
          
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Checkpoint"))
        {
            lastCheckpoint = other.transform;
            Debug.Log("Checkpoint set");
        }
    }

}