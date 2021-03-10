using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public float jumpForce;
    private float oldJumpForce;
    public float purplePotionEffective = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        oldJumpForce = jumpForce;

    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }
    // Update is called once per frame
    void Update()
    {
        if (DroppedBridge.onDroppedBridge)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up*5, ForceMode2D.Impulse);
            }
        }
        if (purplePotionEffective > 0) {
            Debug.Log("test:" + purplePotionEffective);
            jumpForce = oldJumpForce + 5;
            purplePotionEffective -= Time.deltaTime;
        }
        else {
            jumpForce = oldJumpForce;
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        // Debug.Log("isGround: " + isGrounded);
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up*1.1f * jumpForce;
        }
        if (Input.GetKey(KeyCode.Space)&&isJumping==true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = 1.1f*Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}
