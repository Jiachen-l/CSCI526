using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGround : MonoBehaviour
{
    public static bool triggerSoccer = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        BoxCollider2D stilt = other.collider.GetComponent<BoxCollider2D>();
        if (stilt != null && stilt.tag == "Stilt")
        {
            triggerSoccer = true;
        }
        Debug.Log("trigger");
        Debug.Log( triggerSoccer);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
