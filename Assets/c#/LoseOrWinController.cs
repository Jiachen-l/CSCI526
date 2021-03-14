using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class LoseOrWinController : MonoBehaviour
{
	public GameObject winMenu;
	public GameObject gameOverMenu;
	public GameObject retryButton;
	public GameObject pauseButton;
	public GameObject helpButton;

    public static int playerHealth;

    public Text text;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = ApplicationData.playerlives;
        isDead = false;
    }


    void Update()
    {
        if (playerHealth <= 0 && !isDead)
        {
            playerHealth = 0;

            isDead = true;
        }

        text.text = "X" + playerHealth.ToString();

    }


    void OnCollisionEnter2D(Collision2D other) {
        // LoseCondition lc = 

        if (other.gameObject.GetComponent<LoseCondition>() != null) {
            ApplicationData.TimeHitObstacle++;
            Damage(other.gameObject.name, other.gameObject.GetComponent<LoseCondition>().damage);
            //loss(other.gameObject.name);
        }

        if (other.gameObject.GetComponent<WinCondition>() != null) {
            win();
        }

        if (other.gameObject.GetComponent<GapCondition>() != null) {
            ApplicationData.TimeFallIntoGap++;
            loss(other.gameObject.name);
        }
    }

    void Damage(string name, int damage)
    {
        playerHealth -= damage;
        //Debug.Log("damage "+ playerHealth);
        Scene scene = SceneManager.GetActiveScene();
        AnalyticsResult ana = Analytics.CustomEvent(
            scene.name,
            new Dictionary<string, object> {
                {"positionPlayerHurt", name}
            }
        );

        if (playerHealth == 0)
        {
            loss(name);
        }
    }

    void loss(string name) {
        Scene scene = SceneManager.GetActiveScene(); 
        gameOverMenu.SetActive(true);
        retryButton.SetActive(false);
        pauseButton.SetActive(false);
        helpButton.SetActive(false); 
        AnalyticsResult ana = Analytics.CustomEvent(
            scene.name,
            new Dictionary<string, object> {
                {"positionPlayerDie", name}
            }
        );        
    }

    void win() {
        Scene scene = SceneManager.GetActiveScene(); 
        ApplicationData.TimeToPassLevel = Time.time - ApplicationData.levelStartTime;
        AnalyticsResult ana = Analytics.CustomEvent(
            scene.name,
            new Dictionary<string, object> {
                {"realTimePlayerSpendToPassThisLevel", ApplicationData.TimeToPassLevel},
                {"TryTimePlayerNeedToPassThisLevel", ApplicationData.levelTryTime},
                {"TimePlayerFallIntoGap", ApplicationData.TimeFallIntoGap},
                {"TimePlayerHitObstacle", ApplicationData.TimeHitObstacle},
                {"CoinsPlayerCollectThisLevel", ApplicationData.coinsGetThisLevel}
            }
        );

        // Debug.Log("ana:" + ana);
        winMenu.SetActive(true);
        retryButton.SetActive(false);
        pauseButton.SetActive(false);
        helpButton.SetActive(false);
    }
}
