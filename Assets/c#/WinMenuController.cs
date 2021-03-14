using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class WinMenuController : MonoBehaviour
{
    // public GameObject winMenu;
    // public bool GameIfOver = false;

    public GameObject pauseButton;

    public GameObject retryButton;

    public GameObject helpButton;

    private Scene scene;

    void Start() {
        scene = SceneManager.GetActiveScene(); 
        ApplicationData.last_scene = scene.buildIndex;
    }


    public void Resume() {
        //RESET COUNTER
        ApplicationData.TimeHitObstacle = 0;
        ApplicationData.TimeFallIntoGap = 0;
        ApplicationData.levelTryTime = 1;
        ApplicationData.levelStartTime = Time.time;
        ApplicationData.coinsGetThisLevel = 0;

        retryButton.SetActive(true);
        pauseButton.SetActive(true);
        helpButton.SetActive(true);

        SceneManager.LoadScene(scene.name);
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame() {

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

    public void nextLevel() {
        //RESET COUNTER
        ApplicationData.TimeHitObstacle = 0;
        ApplicationData.TimeFallIntoGap = 0;
        ApplicationData.levelTryTime = 1;
        ApplicationData.levelStartTime = Time.time;
        ApplicationData.coins += ApplicationData.coinsGetThisLevel;
        ApplicationData.coinsGetThisLevel = 0;
        ApplicationData.playerlives = LoseOrWinController.playerHealth;


        SceneManager.LoadScene(scene.buildIndex + 1);
    }

    public void shop() {
        //enter shop

    	SceneManager.LoadScene("shop");
    }
}
