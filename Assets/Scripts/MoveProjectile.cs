using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public Rigidbody2D projectile; //The projectile's rigidbody
    public float moveSpeed = 10.0f; //The base speed of projectile
    PlayerMovement playerMovement;

    void Start()
    {
        //Get the projectile's rigidbody
        projectile = this.gameObject.GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            // Get the PlayerMovement component from the playerObject
            playerMovement = playerObject.GetComponent<PlayerMovement>();
        }
        SetProjectileVelocity();
    }


    void SetProjectileVelocity()
    {
        if (playerMovement.playerDirection == 1)
        {
            projectile.velocity = new Vector2(1, 0) * moveSpeed;
        }
        else
        {
            projectile.velocity = new Vector2(-1, 0) * moveSpeed;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 20));
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
          
        }



    }
    
    
}