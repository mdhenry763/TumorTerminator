using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;
    public static bool paused;
    

    public void OnPauseClick()
    {
        paused = true;
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnResumeClick()
    {
        pauseScreen.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
    }
    public void OnPauseExitClick()
    {
        pauseScreen.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
        LevelLoader.Instance.LoadLevel(SceneNames.MainMenu);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnBeginGame()
    {
        LevelLoader.Instance.LoadLevel(SceneNames.Testicle);
    }
}
