using System.Collections;
using UnityEngine;

public class Death : MonoBehaviour
{
    private int pickedClip;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Transform playerTransform = other.transform;
            PlayerMovement playerMovement = playerTransform.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                playerMovement.lives--;

                if (playerMovement.lives > 0)
                {
                    pickedClip = Random.Range(0, 1);

                    if (pickedClip == 0)
                    {
                        playerMovement.playerAudioSource.PlayOneShot(playerMovement.deathClipArray[pickedClip]);
                        StartCoroutine(WaitForAudioClip(playerMovement.playerAudioSource));
                    }

                    // Move the player to the last checkpoint after the audio clip finishes
                    StartCoroutine(TeleportAfterDelay(playerTransform, playerMovement.lastCheckpoint.position));

                }
                else
                {
                    playerMovement.playerAudioSource.PlayOneShot(playerMovement.gameOverClip);
                    StartCoroutine(WaitForAudioClip(playerMovement.playerAudioSource));
                }
            }
        }
    }

    IEnumerator WaitForAudioClip(AudioSource audioSource)
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        // Code here will execute after the audio clip has finished playing
        Debug.Log("Audio clip has finished playing!");
    }

    IEnumerator TeleportAfterDelay(Transform playerTransform, Vector3 targetPosition)
    {
        // Wait for some time (you can adjust the duration)
        yield return new WaitForSeconds(1.0f);

        // Move the player to the last checkpoint after the delay
        playerTransform.position = targetPosition;
    }
}