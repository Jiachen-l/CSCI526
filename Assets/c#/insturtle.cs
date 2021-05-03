using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insturtle : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject eneDialog;
    public int damage = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            eneDialog.SetActive(false);
            eneDialog.SetActive(true);

        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
