﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherGameOverController : MonoBehaviour
{

    public GameObject gameOverMenu;

    public GameObject pauseButton;

    public GameObject retryButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "bone_3" || other.gameObject.name == "bone_4") {
            gameOverMenu.SetActive(true);
            retryButton.SetActive(false);
            pauseButton.SetActive(false);
        }
    }
}