﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour
{
    public int damage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            HealthManager.HurtPlayer(damage);
        }
    }
}
