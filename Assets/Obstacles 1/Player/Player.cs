using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _jumpKeyWasPressed;
    private float _horizontalInput;

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(_horizontalInput*5, 0);
    }
}
