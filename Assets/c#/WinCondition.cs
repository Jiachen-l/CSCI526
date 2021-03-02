using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject winMenu;

    public GameObject retryButton;

    public GameObject pauseButton;

    public GameObject helpButton;

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "bone_3" || other.gameObject.name == "bone_4") {
            winMenu.SetActive(true);
            retryButton.SetActive(false);
            pauseButton.SetActive(false);
            helpButton.SetActive(false);
        }
    }
}
