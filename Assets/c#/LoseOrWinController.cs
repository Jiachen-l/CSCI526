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

    public GameObject[] checkPoints;
    public static GameObject restartCheckPoint;
    private SpriteRenderer bodySprite;
    private SpriteRenderer headSprite;

    public static int playerHealth;

    public Text text;
    public bool isDead;

    private bool flashActive;
    public float flashLength = 0.5f;
    public float flashCounter;


    // Start is called before the first frame update
    void Start()
    {
        bodySprite = GameObject.Find("Body").GetComponent<SpriteRenderer>();
        headSprite = GameObject.Find("Head").GetComponent<SpriteRenderer>();
        checkPoints = GameObject.FindGameObjectsWithTag("CheckPoints");
        playerHealth = ApplicationData.playerlives;
        isDead = false;
    }


    void Update()
    {
        if (flashActive)
        {
            if (flashCounter > flashLength * .66f)
            {
                bodySprite.color = Color.red;
                headSprite.color = Color.red;
            }
            else if (flashCounter > flashLength * .33f)
            {
                bodySprite.color = Color.white;
                headSprite.color = Color.white;
            }
            else if (flashCounter > 0f)
            {
                bodySprite.color = Color.red;
                headSprite.color = Color.red;
            }
            else
            {
                bodySprite.color = Color.white;
                headSprite.color = Color.white;
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }

        if (playerHealth <= 0 && !isDead)
        {
            playerHealth = 0;

            isDead = true;
        }

        text.text = "X" + playerHealth.ToString();

    }

    private bool checkIgnoreCollisions(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (checkIgnoreCollisions(other))
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>());
        }

        if (other.gameObject.GetComponent<LoseCondition>() != null)
        {
            ApplicationData.TimeHitObstacle++;
            if (checkDamage(other))
            {
                damage(other, 1);
            }
        }

        if (other.gameObject.GetComponent<WinCondition>() != null)
        {
            win();
        }

        if (other.gameObject.GetComponent<GapCondition>() != null)
        {
            ApplicationData.TimeFallIntoGap++;
            damage(other, 1);
        }
    }

    private bool checkDamage(Collision2D other)
    {
        if (other.gameObject.name == "LavaTilemap" && (this.gameObject.name == "bone_3" || this.gameObject.name == "bone_4"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void damage(Collision2D other, int damage)
    {
        string name = other.gameObject.name;
        // int damage = other.gameObject.GetComponent<LoseCondition>().damage;
        playerHealth -= damage;
        Scene scene = SceneManager.GetActiveScene();
        AnalyticsResult ana = Analytics.CustomEvent(
            scene.name,
            new Dictionary<string, object> {
                {"PositionPlayerLoseLives", name}
            }
        );

        Debug.Log("ana:"+ ana);

        backToCheckPoint(other);

        if (playerHealth == 0)
        {
            lose(name);
        }
    }

    void backToCheckPoint(Collision2D other)
    {
        flashActive = true;
        flashCounter = flashLength;
        GameObject character = ChangeCharacter.characterIndex == 0 ? GameObject.Find("XRpro") : GameObject.Find("XR");

        int i;
        for (i = 0; i < checkPoints.Length - 1; i++)
        {
            if (
                other.gameObject.transform.position.x >= checkPoints[i].transform.position.x &&
                other.gameObject.transform.position.x < checkPoints[i + 1].transform.position.x)
            {
                character.transform.position = checkPoints[i].transform.position + new Vector3(0.0f, 1.0f);
                break;
            }
        }
        if (i == checkPoints.Length - 1)
        {
            character.transform.position = checkPoints[i].transform.position + new Vector3(0.0f, 1.0f);
        }
    }
    void lose(string name)
    {
        if (ScoreManager.score == 0)
        {
            gameOverMenu.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = "No Coin Left!";
        }
        
        Scene scene = SceneManager.GetActiveScene();
        gameOverMenu.SetActive(true); 
        retryButton.SetActive(false);
        pauseButton.SetActive(false);
        helpButton.SetActive(false);
    }

    void win()
    {
        Scene scene = SceneManager.GetActiveScene();
        ApplicationData.TimeToPassLevel = Time.time - ApplicationData.levelStartTime;
        AnalyticsResult ana = Analytics.CustomEvent(
            scene.name,
            new Dictionary<string, object> {
                {"RealTimeOfPlayerSpendToPassThisLevel", ApplicationData.TimeToPassLevel},
                {"TryNumberofPlayerNeedToPassThisLevel", ApplicationData.levelTryTime},
                {"NumberOfPlayerFallIntoGap", ApplicationData.TimeFallIntoGap},
                {"NumberOfPlayerHitObstacle", ApplicationData.TimeHitObstacle},
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
