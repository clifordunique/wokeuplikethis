using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseBtn : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;



    // Update is called once per frame
    void Update()
    {
        
    }

   public void PausedClick()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Paused();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;


    }
    void Paused()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
