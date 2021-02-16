using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soccer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        Vector2 force = new Vector2(-2, 0);
        body.velocity = force;
    }
}
