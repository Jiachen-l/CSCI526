using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Analytics;

public class shop : MonoBehaviour
{   
    public Text coins;
    public Text hammers;
    public Text fans;
    public Text heathiers;
    private Scene scene;
    public void start() {
        scene = SceneManager.GetActiveScene(); 
        //coins = GameObject.Find("coin_num_text"); 
        //coins.text="X5"; 
    }

    // Start is called before the first frame update
    public void buy_hammer() {
        if (ApplicationData.coins < 5) {
            
        }
        else {
            ApplicationData.coins -= 5;     
            ApplicationData.hammer_num += 1;
            ScoreManager.instance.ChangeHammer(1);
            ScoreManager.instance.ChangeScore(-5);

            AnalyticsResult ana = Analytics.CustomEvent(
                "ToolsAnalytics",
                new Dictionary<string, object> {
                    {"ToolCounter", "hammer"}
                }
            );                
            //GameObject.GetComponent<UnityEngine.UI.Text>().text = ApplicationData.coins.ToString();
            //gameObject.Find("hammer_num_text").GetComponent(UI.Text).text="X"+ApplicationData.hammer_num;
        }
        

    }

    public void buy_fan() {
        if (ApplicationData.coins < 5) {
            
        }
        else {
            ApplicationData.coins -= 5;
            ApplicationData.fan_num += 1;
            ScoreManager.instance.ChangeFan(1);
            ScoreManager.instance.ChangeScore(-5);
            AnalyticsResult ana = Analytics.CustomEvent(
                "ShopAnalytics",
                new Dictionary<string, object> {
                    {"ToolCounter", "fan"}
                }
            );             
            //gameObject.Find("coin_num_text").GetComponent(UI.Text).text="X"+ApplicationData.coins;
            //gameObject.Find("hammer_num_text").GetComponent(UI.Text).text="X"+ApplicationData.fan_num;
        }
        
    }

    public void buy_heathier() {
        if (ApplicationData.coins < 5) {
            
        }
        else {
            ApplicationData.coins -= 5;
            ApplicationData.heathier_num += 1;
            ScoreManager.instance.ChangeHealthier(1);
            ScoreManager.instance.ChangeScore(-5);
            AnalyticsResult ana = Analytics.CustomEvent(
                "ShopAnalytics",
                new Dictionary<string, object> {
                    {"ToolCounter", "heathier"}
                }
            );             
            //gameObject.Find("coin_num_text").GetComponent(UI.Text).text="X"+ApplicationData.coins;
            //gameObject.Find("hammer_num_text").GetComponent(UI.Text).text="X"+ApplicationData.heathier_num;
        }
        
    }

    public void buy_coin() {
        ApplicationData.coins += 10;
        ScoreManager.instance.ChangeScore(10);
        Debug.Log("buy coin");
        AnalyticsResult ana = Analytics.CustomEvent(
                "ShopAnalytics",
                new Dictionary<string, object> {
                    {"MoneyPlayerSpend", "money X 10"}
                }
            ); 
        //gameObject.Find("coin_num_text").GetComponent(UI.Text).text="X"+ApplicationData.coins;
        //GameObject.GetComponent<UnityEngine.UI.Text>().text = ApplicationData.coins.ToString();
    }

    public void next() {
        if (ApplicationData.last_scene == 0) {
            SceneManager.LoadScene("level1");
        }
        else if (ApplicationData.last_scene == 1) {
            SceneManager.LoadScene("level2");
        }
        else {
            SceneManager.LoadScene("Menu");
        }
        
    }


}
