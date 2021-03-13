using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWoodBridge : MonoBehaviour
{
    public float speed = 3;

    private float changeDirectionTime = 2f;//time to change direction

    public float changeTimer;

    private Rigidbody2D rbody;

    public bool isVertical;

    private Vector2 moveDirection;

    public Rigidbody2D player;
    
    public static bool onMovingBridge = false;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() == player)
        {
            // set gravity to 100 so that the player won't move (move closely with bridge) if it is on the moving wood bridge
            player.gravityScale = 100;
            onMovingBridge = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        player.gravityScale = 3;
        onMovingBridge = false;
    }
}
