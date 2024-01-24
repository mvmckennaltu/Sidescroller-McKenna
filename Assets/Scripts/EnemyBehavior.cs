using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public AudioSource enemyAudioSource;
    private Rigidbody2D rb2d;
    public int playerDetected = 0;
    public float enemyMoveSpeed = 3.0f;
    public int enemyDirection = 1;
    private float moveHorizontal = 0.0f;
    PlayerMovement playerMovement;
    Death death;
    GameObject playerObject;
    GameObject deathObject;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            // Get the PlayerMovement component from the playerObject
            playerMovement = playerObject.GetComponent<PlayerMovement>();
        }
        deathObject = GameObject.FindWithTag("Death Barrier");
        if (deathObject != null)
        {
            
            death = deathObject.GetComponent<Death>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(moveHorizontal * enemyMoveSpeed, rb2d.velocity.y);
        Pace();

    }
    public void Pace()
    {
        enemyMoveSpeed = 3.0f;
        if (playerDetected == 0)
        {
            if (enemyDirection == 1)
            {
                moveHorizontal = 1.0f;
            }
            else
            {
                moveHorizontal = -1.0f;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Rigidbody2D otherRb2d = collision.gameObject.GetComponent<Rigidbody2D>();
            if(otherRb2d != null)
            {
                float pushForce = 100.0f;
                Vector2 pushForceDirection = (otherRb2d.transform.position - transform.position).normalized;
                otherRb2d.AddForce(pushForceDirection * pushForce, ForceMode2D.Impulse);
            }
            death.PlayerDeath();

        }
    }
}
