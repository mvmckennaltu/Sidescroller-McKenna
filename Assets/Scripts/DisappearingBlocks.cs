using System.Collections;
using UnityEngine;

public class DisappearingBlocks : MonoBehaviour
{
    public float setTime = 10.0f;
    public GameObject block;
    public AudioClip switchClip;
    void Update()
    {
        // Check if the timer is greater than zero before subtracting Time.deltaTime
        if (setTime > 0)
        {
            setTime -= Time.deltaTime;

            // If the timer reaches zero, toggle the block's active state and reset the timer
            if (setTime <= 0)
            {
                // Toggle the active state of the block
                ToggleBlock();

                // Reset the timer
                setTime = 5.0f;
            }
        }
    }

    void ToggleBlock()
    {
        // Get the SpriteRenderer component
        SpriteRenderer spriteRenderer = block.GetComponent<SpriteRenderer>();

        // Check if the SpriteRenderer component is not null
        if (spriteRenderer != null)
        {
            // Toggle the enabled state of the SpriteRenderer
            spriteRenderer.enabled = !spriteRenderer.enabled;
            AudioSource.PlayClipAtPoint(switchClip,block.transform.position);

        }

        // Get the Collider2D component
        Collider2D collider = block.GetComponent<Collider2D>();

        // Check if the Collider2D component is not null
        if (collider != null)
        {
            // Toggle the enabled state of the Collider2D
            collider.enabled = !collider.enabled;
        }
    }
}