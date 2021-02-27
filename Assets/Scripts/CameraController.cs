using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float offsetSmoothing;

    [SerializeField]
    private Vector2 maxPos;
    [SerializeField]
    private Vector2 minPos;

    void LateUpdate()
    {
        //playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        if (transform.position != player.transform.position)
        {
            Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            //playerPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

            //if (player.transform.localScale.x > 0f) // Move camera a bit right if walking right 
            //{
            //playerPos.x = Mathf.Clamp(playerPos.x + offset, minPos.x, maxPos.x);
            // }
            //else if (player.transform.localScale.x < 0f) // Move camera a bit left if walking left 
            //{
            //playerPos.x = Mathf.Clamp(playerPos.x - offset, minPos.x, maxPos.x);

            //}
            // else if (player.transform.localScale.y > 0f)
            //{
            //playerPos.y = Mathf.Clamp(playerPos.y + offset, minPos.y, maxPos.y);
            // }
            // else if (player.transform.localScale.y < 0f)
            //{
            //playerPos.y = Mathf.Clamp(playerPos.y - offset, minPos.y, maxPos.y);
            //}
            playerPos.x = Mathf.Clamp(playerPos.x, minPos.x, maxPos.x);
            playerPos.y = Mathf.Clamp(playerPos.y, minPos.y, maxPos.y);
            transform.position = Vector3.Lerp(transform.position, playerPos, offsetSmoothing * Time.deltaTime);
        }
    }
}
