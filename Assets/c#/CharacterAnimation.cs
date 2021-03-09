using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isWalking", true);
            // Debug.Log("left or right down");
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }
    }
}
