using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    public GameObject playerObject;

    private PlayerController player;
    private HealthManager healthManager;

    private float respawnDelay = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer() {

        StartCoroutine("RespawnPlayerCo");
        
    }

    public IEnumerator RespawnPlayerCo()
    {
        //player.enabled = false;
        //gravityScale = player.rb.gravityScale;
        //player.rb.gravityScale = 0f;
        playerObject.SetActive(false);
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawnDelay);
        
        player.transform.position = currentCheckpoint.transform.position;
        playerObject.SetActive(true);
        //player.enabled = true;
        healthManager.FullHealth();
        healthManager.isDead = false;
        //player.rb.gravityScale = gravityScale;
        
    }

}
