using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increment_health()
    {
        if (ApplicationData.heathier_num > 0) {
            ApplicationData.playerlives++;
            ApplicationData.heathier_num--;
        }
        // ApplicationData.playerlives++;
        // ApplicationData.heathier_num--;
        //Debug.Log("increment health");
    }

    public void fan()
    {
        //Debug.Log("increment health");
    }

    public void hammer()
    {
        //Debug.Log("increment health");
    }
}
