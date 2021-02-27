using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float respawnDelay;
    public PlayerControl gamePlayer;

    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }


    public IEnumerator RespawnCoroutine()
    {
        // Adding delay in a separate function just so the whole code does not delay 
        // Disabling the player and then setting its position to respawn point
        // And then enabling the player back on 

        yield return new WaitForSeconds(respawnDelay); // Wait for 'respawn delay' seconds to respawn the player 
        gamePlayer.transform.position = gamePlayer.respawnPoint;
    }
}
