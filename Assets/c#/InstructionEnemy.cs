using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject eneDialog;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            eneDialog.SetActive(true);
        }
    }
}
