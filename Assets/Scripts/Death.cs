using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Death : MonoBehaviour
{
    private int pickedClip;
    public TextMeshProUGUI livesCountText;
    PlayerMovement playerMovement;
    GameObject playerObject;
    private void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            // Get the PlayerMovement component from the playerObject
            playerMovement = playerObject.GetComponent<PlayerMovement>();
        }
    }
    void Update()
    {

        livesCountText.text = playerMovement.lives.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Transform playerTransform = other.transform;
            PlayerDeath();

        }
        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
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
        playerMovement.rb2d.velocity = Vector2.zero;
        // Move the player to the last checkpoint after the delay
        playerTransform.position = targetPosition;
    }
    public void PlayerDeath()
    {
        
        if (playerMovement != null)
        {
            playerMovement.lives--;

            if (playerMovement.lives > 0)
            {
                pickedClip = Random.Range(0, 1);

                playerMovement.playerAudioSource.PlayOneShot(playerMovement.deathClipArray[pickedClip]);
                StartCoroutine(WaitForAudioClip(playerMovement.playerAudioSource));

                
                // Move the player to the last checkpoint after the audio clip finishes
                StartCoroutine(TeleportAfterDelay(playerObject.transform, playerMovement.lastCheckpoint.position));

            }
            else
            {
                playerMovement.playerAudioSource.PlayOneShot(playerMovement.gameOverClip);
                StartCoroutine(WaitForAudioClip(playerMovement.playerAudioSource));
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}