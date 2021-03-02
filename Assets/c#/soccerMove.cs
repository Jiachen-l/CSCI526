using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soccerMove : MonoBehaviour
{

    public float speed = 3;

    private float changeDirectionTime = 2f;//time to change direction

    public float changeTimer;

    private Rigidbody2D rbody;

    public bool isVertical;

    private Vector2 moveDirection;

    public GameObject gameOverMenu;

    public GameObject pauseButton;

    public GameObject retryButton;

    public GameObject[] checkPoints;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        
        moveDirection = isVertical ? Vector2.up : Vector2.right;

        changeTimer = changeDirectionTime;

        checkPoints = GameObject.FindGameObjectsWithTag("checkpoint");
    }

    // Update is called once per frame
    void Update()
    {
        changeTimer -= Time.deltaTime;
        if (changeTimer < 0) {
            moveDirection *= -1;
            changeTimer = changeDirectionTime;
        }

        Vector2 position = rbody.position;
        position.x += moveDirection.x * speed * Time.deltaTime;
        position.y += moveDirection.y * speed * Time.deltaTime;
        rbody.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other) {
        //        if (other.gameObject.name == "bone_3" || other.gameObject.name == "bone_4") {
        //            gameOverMenu.SetActive(true);
        //            retryButton.SetActive(false);
        //            pauseButton.SetActive(false);
        //        }
        if (other.gameObject.name == "bone_3" || other.gameObject.name == "bone_4")
        {
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
                Debug.Log("CheckPoint " + i);
                GameObject.Find("bone_1").transform.position = checkPoints[i].transform.position;
                GameObject.Find("bone_3").transform.position = checkPoints[i].transform.position;
                GameObject.Find("bone_4").transform.position = checkPoints[i].transform.position;
            }

        }
    }
}
