using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverMenu;
    public bool GameIfOver = false;

    public GameObject pauseButton;

    public GameObject retryButton;

    public GameObject helpButton;


    public void Resume() {
        Debug.Log("retry Time:" + ApplicationData.levelTryTime);
        retryButton.SetActive(true);
        pauseButton.SetActive(true);
        helpButton.SetActive(true);
        Scene scene = SceneManager.GetActiveScene(); 
        ApplicationData.levelTryTime++;
        ApplicationData.coinsGetThisLevel = 0;

        SceneManager.LoadScene(scene.name);
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {
        Scene scene = SceneManager.GetActiveScene(); 
        AnalyticsResult ana = Analytics.CustomEvent(
            "playerQuitAnalytics",
            new Dictionary<string, object> {
                {"timePlayerSpendInThisGame", Time.time},
                {"levelPlayerQuitThisGame", scene.name}
            }
        );           
        Debug.Log("Quit Game...");
        Application.Quit();
    }
}
