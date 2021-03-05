using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class LoseOrWinController : MonoBehaviour
{
	public GameObject winMenu;
	public GameObject gameOverMenu;
	public GameObject retryButton;
	public GameObject pauseButton;
	public GameObject helpButton;
    private bool isGameOver = false;

    void Update() {
        if (!isGameOver) {
            if (this.gameObject.transform.position.y < -20) {
                isGameOver = true;
                loss();
                ApplicationData.TimeFallIntoGap++;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D other) {
        // LoseCondition lc = 

        if (other.gameObject.GetComponent<LoseCondition>() != null) {
            ApplicationData.TimeHitObstacle++;
            loss();
        }

        if (other.gameObject.GetComponent<WinCondition>() != null) {
            win();
        }
    }

    void loss() {
        gameOverMenu.SetActive(true);
        retryButton.SetActive(false);
        pauseButton.SetActive(false);
        helpButton.SetActive(false); 
    }

    void win() {
        Scene scene = SceneManager.GetActiveScene(); 
        ApplicationData.TimeToPassLevel = Time.time - ApplicationData.levelStartTime;
        AnalyticsResult ana = Analytics.CustomEvent(
            scene.name,
            new Dictionary<string, object> {
                {"TimeToPassLevel0", ApplicationData.TimeToPassLevel},
                {"TryTimeToPassLevel0", ApplicationData.levelTryTime},
                {"TimeFallIntoGap", ApplicationData.TimeFallIntoGap},
                {"TimeHitObstacle", ApplicationData.TimeHitObstacle}
            }
        );

        // Debug.Log("ana:" + ana);
        winMenu.SetActive(true);
        retryButton.SetActive(false);
        pauseButton.SetActive(false);
        helpButton.SetActive(false);
    }
}
