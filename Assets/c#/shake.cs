using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{
    public Animator can_anim;

    public void can_shake() {
        Debug.Log("enter can_shake");
        can_anim.SetTrigger("shake");
        Debug.Log("leave can_shake");
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
