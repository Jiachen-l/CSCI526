using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGround : MonoBehaviour
{
    
    public static bool triggerSoccer = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        // GameObject stilt = GameObject.FindWithTag("Stilt");
        BoxCollider2D stilt = other.collider.GetComponent<BoxCollider2D>();
        if (stilt != null && stilt.CompareTag("Stilt"))
        {
            triggerSoccer = true;
        }
        Debug.Log("trigger is ");
        Debug.Log(other.collider);
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
