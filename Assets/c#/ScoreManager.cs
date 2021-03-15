using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    // public Text text;
    public Text coins_text;
    public Text hammer_text;
    public Text fan_text;
    public Text healthier_text;

    public static int coin;
    private int fan_num;
    private int hammer_num;
    private int healthier_num;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        coin = ApplicationData.coins;
        fan_num = 0;
        hammer_num = 0;
        healthier_num = 0;
    }


    public void ChangeScore(int value)
    {
        coin += value;
    }

    public void ChangeHammer(int value)
    {
        hammer_num += value;
    }

    public void ChangeFan(int value)
    {
        fan_num += value;
    }

    public void ChangeHealthier(int value)
    {
        healthier_num += value;
    }

    private void Update()
    {
        coins_text.text = "X" + coin.ToString();
        hammer_text.text = "X" + hammer_num.ToString();
        fan_text.text = "X" + fan_num.ToString();
        healthier_text.text = "X" + healthier_num.ToString();
    }



}
