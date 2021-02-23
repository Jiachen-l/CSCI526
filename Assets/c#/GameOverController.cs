using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverMenu;
    public bool GameIfOver = false;

    public GameObject pauseButton;

    public GameObject retryButton;

    public void Resume() {
        retryButton.SetActive(true);
        pauseButton.SetActive(true);
    	SceneManager.LoadScene("level1");
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        Debug.Log("Quit Game...");
        Application.Quit();
    }
}
