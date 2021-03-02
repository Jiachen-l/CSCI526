using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //onTriggerEnter();
    }

    void Movement()
    {
        float horizontalmove;
        horizontalmove = Input.GetAxis("Horizontal");
        if (horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "XRgrow")
        {
            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
            gameObject.transform.localScale = new Vector2(2, 2);

        }
        else if(collision.tag == "XRshrink")
        {
            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
            gameObject.transform.localScale = new Vector2(1, 1);
        }
    }
}
