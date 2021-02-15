﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soccerMove : MonoBehaviour
{

    public float speed = 3;

    public float changeDirectionTime = 2f;//time to change direction

    public float changeTimer;

    private Rigidbody2D rbody;

    public bool isVertical;

    private Vector2 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        
        moveDirection = isVertical ? Vector2.up : Vector2.right;

        changeTimer = changeDirectionTime;
    }

    // Update is called once per frame
    void Update()
    {
        changeTimer -= Time.deltaTime;
        if (changeTimer < 0) {
            moveDirection *= -1;
            changeTimer = changeDirectionTime;
        }

        Vector2 position = rbody.position;
        position.x += moveDirection.x * speed * Time.deltaTime;
        position.y += moveDirection.y * speed * Time.deltaTime;
        rbody.MovePosition(position);
    }
}
