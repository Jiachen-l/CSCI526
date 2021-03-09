using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBat : MonoBehaviour
{

    private Rigidbody2D rbody;
    private float delta = 2.5f;
    private float speed = 2.5f;
    private Vector2 startPos;
    
    private Vector2 moveDirection = Vector2.up;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 p = startPos;
        p.y += delta * (float)Math.Sin(Time.time * speed);
        transform.position = p;
    }


}
