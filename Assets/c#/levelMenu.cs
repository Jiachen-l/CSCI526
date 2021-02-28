using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelMenu : MonoBehaviour
{
    public void level_one() {
        SceneManager.LoadScene("level1");
    }

    public void level_two() {
        
    }

    public void back() {
        SceneManager.LoadScene("Menu");
    }
}
