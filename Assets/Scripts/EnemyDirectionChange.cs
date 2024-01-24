using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirectionChange : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemyBehavior = GetComponentInParent<EnemyBehavior>();
        if (!collision.CompareTag("Ground"))
        {
            Debug.Log("Enemy detected something that isn't the ground");
            if (enemyBehavior.enemyDirection == 1)
            {
                enemyBehavior.enemyDirection = 0;
            }
            else if (enemyBehavior.enemyDirection == 0)
            {
                enemyBehavior.enemyDirection = 1;
            }
            Debug.Log("Current direction: " + enemyBehavior.enemyDirection);
        }
    }
}
