using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionCoin : MonoBehaviour
{
    public int coinValue = 1;
    public GameObject coinDialog;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            coinDialog.SetActive(false);
            coinDialog.SetActive(true);
            ScoreManager.instance.ChangeScore(coinValue);
            ApplicationData.coinsGetThisLevel++;
            ApplicationData.coinsLeftThisLevel++;
            Destroy(this.gameObject);

        }
    }
}
