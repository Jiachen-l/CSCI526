using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StiltController : MonoBehaviour
{
    [SerializeField]
    private RotateController stiltsController;
    private byte groundsCount =0 ;

    private Rigidbody2D rb;
    private float a = 9f;
    private float speed = 1f;

    public bool rs = false;

    private void Start()
    {
        stiltsController = GetComponentInParent<RotateController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (groundsCount == 0)
        {
            speed += Time.fixedDeltaTime * a;
            rb.position += Vector2.down * speed * Time.fixedDeltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            if (stiltsController.stilt == gameObject)
            {
                stiltsController.canMove = false;
            }

            groundsCount++;
            speed = 1f;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            groundsCount--;
            stiltsController.canMove = true;


        }
    }
}
