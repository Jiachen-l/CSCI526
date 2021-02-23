﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject pauseButton;

    public GameObject retryButton;


    // Update is called once per frame
    void Update()
    {

    }

    public void Resume() {
        retryButton.SetActive(true);
        pauseButton.SetActive(true);
    	pauseMenuUI.SetActive(false);
    	Time.timeScale = 1f;
    	GameIsPaused = false;
    }

    public void Pause() {
        retryButton.SetActive(false);
        pauseButton.SetActive(false);
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
        SceneManager.LoadScene("level1");    
        }
}
