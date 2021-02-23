using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocoController : MonoBehaviour
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

        moveDirection *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        changeTimer -= Time.deltaTime;
        if (changeTimer < 0) {
            moveDirection *= -1;
            changeTimer = changeDirectionTime;
            rbody.transform.Rotate(0, 180, 0);
        }

        Vector2 position = rbody.position;
        position.x += moveDirection.x * speed * Time.deltaTime;
        position.y += moveDirection.y * speed * Time.deltaTime;
        rbody.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other) {
        GameObject gb = other.gameObject;
        Debug.Log(gb.name);
        if (gb.transform.parent != null) {
            TestController tc = gb.transform.parent.parent.gameObject.GetComponent<TestController>();
            Debug.Log(tc.gameObject.name);
            tc.gameover();
        }
    }
}
