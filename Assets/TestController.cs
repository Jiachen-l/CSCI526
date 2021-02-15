﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public Rigidbody2D lrb;
    public Rigidbody2D rrb;
    public Rigidbody2D character;
    private float speedX = 1f;
    private float speedY = 2f;
    public bool canMove = false;
    private bool rightLeft = true;

    public Rigidbody2D stilt
    {
        get
        {
            if (rightLeft)
            {
                return rrb;
            }
            else
            {
                return lrb;
            }
        }
    }

    public Rigidbody2D stilt2
    {
        get
        {
            if (!rightLeft)
            {
                return rrb;
            }
            else
            {
                return lrb;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // float moveX = Input.GetAxisRaw("Horizontal"); // 控制水平移动方向 A:-1 D:1  :0
        // float moveY = Input.GetAxisRaw("Vertical"); // 控制垂直移动防线 W:1 S:-1  :0

        // Vector2 moveVector = new Vector2(moveX, moveY);
        // Vector2 position = rb.position;
        // position += moveVector * speed * Time.deltaTime;
        // rb.MovePosition(position);

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {   
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(rightLeft);
            }

            canMove = true;
            
            StartCoroutine(MoveStilts());
            // // stilt2.bodyType=RigidbodyType2D.Static;
            // Vector2 stiltPosition = stilt.position;
            // Vector2 characterPosition = character.position;

            // stiltPosition += Vector2.right * speedX * Time.fixedDeltaTime;
            // stiltPosition += Vector2.up * speedY * Time.fixedDeltaTime;
            // characterPosition += Vector2.right * speedX * Time.fixedDeltaTime;
            // characterPosition += Vector2.up * speedY * Time.fixedDeltaTime;

            // stilt.MovePosition(stiltPosition);
            // character.MovePosition(characterPosition);
            // // stilt2.bodyType=RigidbodyType2D.Dynamic;
        }
        else if (canMove == false || Input.GetMouseButtonUp(0))
        {
            canMove = false;
            rightLeft = rrb.position.x < lrb.position.x;
        }
    }

    private IEnumerator MoveStilts()
    {
        for (int i = 0; i < 5; i++)
        {
            
            stilt.position += Vector2.right * speedX * Time.fixedDeltaTime;
            stilt.position += Vector2.up * speedY * Time.fixedDeltaTime;
            Vector2 characterPosition = (stilt.position + stilt2.position) / 2;
            characterPosition.y = character.position.y;
            character.MovePosition(characterPosition);
            // character.position += Vector2.up * speedY * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        
    }
}
