using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("LevelMenu");
    }

    public void QuitGame() {
    	Scene scene = SceneManager.GetActiveScene();
        AnalyticsResult ana = Analytics.CustomEvent(
            scene.name,
            new Dictionary<string, object> {
                {"PlayerPlayTime", Time.time},
                {"LevelPlayerStop", scene.name}
            }
        );         	
        Debug.Log("Quit!");
        Application.Quit();
    }
}
