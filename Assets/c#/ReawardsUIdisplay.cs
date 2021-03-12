﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReawardsUIdisplay : MonoBehaviour
{
    private int health = 5;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HEALTH:" + health;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            health--;
        }
    }
}
