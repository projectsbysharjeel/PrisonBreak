using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool moving;
    public Vector3 pos1; // position start
    public Vector3 pos2; // position end
    public float speed = 1.0f;
    private float movement = 0f; // Player movement

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal"); // move left and right
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f)); 
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moving = true;
            collision.collider.transform.SetParent(transform);
            collision.transform.localScale = new Vector2(0.6836291f / 0.4f, 0.6836291f / 0.4f);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
            collision.transform.localScale = new Vector2(0.6836291f, 0.6836291f);
            moving = false;
        }
    }
    private void FixedUpdate()
    {
        if (moving)
        {
            transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
        }
    }
}
