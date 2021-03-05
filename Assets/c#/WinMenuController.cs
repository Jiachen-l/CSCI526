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
    }


    public void Resume() {
        //RESET COUNTER
        ApplicationData.TimeHitObstacle = 0;
        ApplicationData.TimeFallIntoGap = 0;
        ApplicationData.levelTryTime = 1;
        ApplicationData.levelStartTime = Time.time;

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
            scene.name,
            new Dictionary<string, object> {
                {"PlayerPlayTime", Time.time},
                {"LevelPlayerStop", scene.name}
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

    	SceneManager.LoadScene(scene.buildIndex + 1);
    }
}
