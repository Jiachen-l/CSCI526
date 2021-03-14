using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    public int startLives;
    private int lifeCounter;
    private Text theText;

    // Start is called before the first frame update
    void Start()
    {
        theText = GetComponent<Text>();
        lifeCounter = startLives;
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeCounter <= 0)
        {

        }
        theText.text = "X " + lifeCounter;
    }

    public void GiveLife()
    {
        lifeCounter++;
    }

    public void TakeLife()
    {
        lifeCounter--;
    }
}
