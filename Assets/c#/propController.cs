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
        if (ApplicationData.heathier_num > 0) {
            ApplicationData.playerlives++;
            ApplicationData.heathier_num--;
        }
        // ApplicationData.playerlives++;
        // ApplicationData.heathier_num--;
        //Debug.Log("increment health");
    }

    public void fan()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("fan_enemy");
        Debug.Log(objs.Length.ToString());
        for (int i = 0; i < objs.Length; i++)
        {
            Debug.Log(objs[i].name);
            objs[i].SetActive(false);
        }
    }

    public void hammer()
    {
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
        //Debug.Log("increment health");
    }
}
