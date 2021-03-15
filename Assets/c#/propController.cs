using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increment_health()
    {
        //for test only
        //ScoreManager.instance.ChangeHealthier(5);
        if (ScoreManager.instance.GetHealthier() > 0) {
            LoseOrWinController.playerHealth++;
            ScoreManager.instance.ChangeHealthier(-1);
        }
        // LoseOrWinController.playerHealth++;
        // ApplicationData.heathier_num--;
        //Debug.Log("increment health");
    }

    public void fan()
    {
        //for test only
        //ScoreManager.instance.ChangeFan(5);
        if (ScoreManager.instance.GetFan() > 0) {
            ScoreManager.instance.ChangeFan(-1);
            GameObject[] objs = GameObject.FindGameObjectsWithTag("fan_enemy");
            Debug.Log(objs.Length.ToString());
            for (int i = 0; i < objs.Length; i++)
            {
                Debug.Log(objs[i].name);
                objs[i].SetActive(false);
            }
        }
        
    }

    public void hammer()
    {
        //for test only
        //ScoreManager.instance.ChangeHammer(5);
        if (ScoreManager.instance.GetHammer() > 0) {
            ScoreManager.instance.ChangeHammer(-1);
            GameObject[] objs = GameObject.FindGameObjectsWithTag("fan_enemy");
            Debug.Log(objs.Length.ToString());
            for (int i = 0; i < objs.Length; i++)
            {
                Debug.Log(objs[i].name);
                objs[i].SetActive(false);
            }
            GameObject[] objs_hammer = GameObject.FindGameObjectsWithTag("hammer_enemy");
            Debug.Log(objs_hammer.Length.ToString());
            for (int i = 0; i < objs_hammer.Length; i++)
            {
                Debug.Log(objs_hammer[i].name);
                objs_hammer[i].SetActive(false);
            }
        }
        
        //Debug.Log("increment health");
    }
}
