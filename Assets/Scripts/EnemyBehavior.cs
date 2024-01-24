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
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(moveHorizontal * enemyMoveSpeed, rb2d.velocity.y);
        Pace();

    }
    void Pace()
    {
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
}
