using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    public GameObject notification;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "bone_3" || other.gameObject.name == "bone_4") {
            Destroy(this.gameObject);
            showNotification();
        }
    }

    void showNotification() {
        notification.SetActive(true);
        Destroy(notification, 5.0f);
        // float i = 0f;
        // while (i < 5 * Time.deltaTime){i += Time.deltaTime;}
        // notification.SetActive(false);
    }
}
