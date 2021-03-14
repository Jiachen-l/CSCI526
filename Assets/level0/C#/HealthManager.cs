using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int playerHealth;

    Text text;
    private LevelManager levelManager;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        text = GetComponent<Text>();
        playerHealth = ApplicationData.playerlives;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0 && !isDead)
        {
            playerHealth = 0;
            levelManager.RespawnPlayer();
            isDead = true;
        }

        text.text = "X" + playerHealth.ToString();

    }

    public static void HurtPlayer(int damage)
    {
        playerHealth -= damage;
    }

    public void FullHealth()
    {
        playerHealth = ApplicationData.playerlives;
    }

}
