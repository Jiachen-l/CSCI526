using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelMenu : MonoBehaviour
{
    public void level_one() {
        SceneManager.LoadScene("level0");
        ApplicationData.TimeHitObstacle = 0;
        ApplicationData.TimeFallIntoGap = 0;
        ApplicationData.levelStartTime = Time.time;
        ApplicationData.levelTryTime = 1;
        ApplicationData.last_scene = 0;
    }

    public void level_two() {
        SceneManager.LoadScene("level1");
        ApplicationData.TimeHitObstacle = 0;
        ApplicationData.TimeFallIntoGap = 0;
        ApplicationData.levelTryTime = 1;
        ApplicationData.levelStartTime = Time.time;
        ApplicationData.last_scene = 1;
    }

    public void level_three() {
        SceneManager.LoadScene("level2");
        ApplicationData.TimeHitObstacle = 0;
        ApplicationData.TimeFallIntoGap = 0;
        ApplicationData.levelTryTime = 1;
        ApplicationData.levelStartTime = Time.time;
        ApplicationData.last_scene = 1;
    }

    public void back() {
        SceneManager.LoadScene("Menu");
    }
}
