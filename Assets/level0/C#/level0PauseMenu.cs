using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level0PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject helpUI;

    public GameObject pauseButton;

    public GameObject retryButton;

    public GameObject helpButton;


    // Update is called once per frame
    void Update()
    {

    }

    public void Resume() {
        Debug.Log("button press");
        retryButton.SetActive(true);
        pauseButton.SetActive(true);
        helpButton.SetActive(true);
    	pauseMenuUI.SetActive(false);
    	Time.timeScale = 1f;
    	GameIsPaused = false;
    }

    public void Pause() {
        retryButton.SetActive(false);
        pauseButton.SetActive(false);
        helpButton.SetActive(false);
    	pauseMenuUI.SetActive(true);
    	Time.timeScale = 0f;
    	GameIsPaused = true;
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        Debug.Log("Quit Game...");
        Application.Quit();
    }

    public void Retry() {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);  
    }

    public void showHelp() {
        helpUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void hideHelp() {
        helpUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
