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
        fan_num = ApplicationData.fan_num;
        hammer_num = ApplicationData.hammer_num;
        healthier_num = ApplicationData.healthier_num;
    }


    public void ChangeScore(int value)
    {
        coin += value;
    }

    public void ChangeHammer(int value)
    {
        ApplicationData.hammer_num += value;
    }

    public void ChangeFan(int value)
    {
        ApplicationData.fan_num += value;
    }

    public void ChangeHealthier(int value)
    {
        ApplicationData.healthier_num += value;
    }

    public int GetHealthier()
    {
        return ApplicationData.healthier_num;
    }

    public int GetHammer()
    {
        return ApplicationData.hammer_num;
    }

    public int GetFan()
    {
        return ApplicationData.fan_num;
    }

    

    private void Update()
    {
        coins_text.text = "X" + coin.ToString();
        hammer_text.text = "X" + ApplicationData.hammer_num.ToString();
        fan_text.text = "X" + ApplicationData.fan_num.ToString();
        healthier_text.text = "X" + ApplicationData.healthier_num.ToString();
    }



}
