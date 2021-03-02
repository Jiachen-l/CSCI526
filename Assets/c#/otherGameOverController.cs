using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class otherGameOverController : MonoBehaviour
{

    public GameObject gameOverMenu;

    public GameObject pauseButton;

    public GameObject retryButton;

    public GameObject[] checkPoints;

    // Start is called before the first frame update
    void Start()
    {
        checkPoints = GameObject.FindGameObjectsWithTag("checkpoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "bone_3" || other.gameObject.name == "bone_4") {
            // gameOverMenu.SetActive(true);
            // retryButton.SetActive(false);
            // pauseButton.SetActive(false);
            int i;
            for (i = 0; i < checkPoints.Length - 1; i++)
            {
                if (
                    other.gameObject.transform.position.x >= checkPoints[i].transform.position.x &&
                    other.gameObject.transform.position.x < checkPoints[i + 1].transform.position.x)
                {
                    GameObject.Find("bone_1").transform.position = checkPoints[i].transform.position;
                    GameObject.Find("bone_3").transform.position = checkPoints[i].transform.position;
                    GameObject.Find("bone_4").transform.position = checkPoints[i].transform.position;
                    break;
                }
            }
            if (i == checkPoints.Length - 1)
            {
                GameObject.Find("bone_1").transform.position = checkPoints[i].transform.position;
                GameObject.Find("bone_3").transform.position = checkPoints[i].transform.position;
                GameObject.Find("bone_4").transform.position = checkPoints[i].transform.position;
            }

        }
    }
}
