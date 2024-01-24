using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseText;
    public GameObject mainMenuButton;
    public GameObject resumeButton;
    public static bool gameIsPaused = false;
    // Start is called before the first frame update
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused == false)
            {
                PauseGame();
            }
            else
            {
                gameIsPaused = false;
                UnpauseGame();
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        pauseText.SetActive(true); mainMenuButton.SetActive(true); resumeButton.SetActive(true);
        gameIsPaused = true;
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1.0f;
        pauseText.SetActive(false); mainMenuButton.SetActive(false); resumeButton.SetActive(false);
        gameIsPaused = false;
    }
}