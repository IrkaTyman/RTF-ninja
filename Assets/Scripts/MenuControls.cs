using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public GameObject loseScreen;
    public GameObject levelScreen;

    public void PlayPressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void MenuPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void SettingsPressed()
    {
        SceneManager.LoadScene("Settings");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartLevelAfterLose()
    {
        loseScreen.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void ContinueAfterLevelWin()
    {
        levelScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
