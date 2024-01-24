using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    private bool isInTrigger = false;
    EnemyBehavior enemyBehavior;
    Transform enemyTransform;
    GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        enemyBehavior = GetComponentInParent<EnemyBehavior>();
        enemyTransform = GetComponentInParent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isInTrigger == true)
        {
            float playerDirection = enemyTransform.position.x - playerObject.transform.position.x;
            enemyBehavior.playerDetected = 1;
            if (playerDirection > 0)
            {
                enemyBehavior.enemyDirection = 0;
                enemyBehavior.enemyMoveSpeed = 6.0f;
                Debug.Log("Player detected on the left.");
            }
            else if (playerDirection < 0)
            {
                enemyBehavior.enemyDirection = 1;
                enemyBehavior.enemyMoveSpeed = 6.0f;
                Debug.Log("Player detected on the right.");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemyTransform = GetComponentInParent<Transform>();
        if (collision.CompareTag("Player"))
        {
           isInTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInTrigger = false;
        enemyBehavior.playerDetected = 0;
        enemyBehavior.Pace();
        Debug.Log("Player exited detection zone.");
    }
}
