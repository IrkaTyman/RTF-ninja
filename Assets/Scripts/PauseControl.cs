using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public GameObject pauseCanvas;
    
    public static bool gameIsPaused;

    void Start() {
        pauseCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame ()
    {
        if(!gameIsPaused && Time.timeScale == 0) {
            return;
        }

        if(gameIsPaused)
        {
            Time.timeScale = 1;
            pauseCanvas.SetActive(false);
        }
        else 
        {
            Time.timeScale = 0f;
            pauseCanvas.SetActive(true);
        }

        gameIsPaused = !gameIsPaused;
        AudioListener.pause = gameIsPaused;
    }
}
