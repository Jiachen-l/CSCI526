using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DroppedBridge : MonoBehaviour
{
    public static bool onDroppedBridge = false;
    
    private Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // player.gravityScale = 1;
        onDroppedBridge = true;
        rbody.velocity = Vector2.down*0.6f;
        rbody.gravityScale = 0;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        onDroppedBridge = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
