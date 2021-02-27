using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    [SerializeField] float moveSpeed;

    Rigidbody2D rb2d;
    private Animator playerAnimation;
    private bool die = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>(); // Accessing the animator to control animations 
    }

    // Update is called once per frame
    void Update()
    {
        // Distance to player 
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        
        if (distToPlayer < agroRange)
        {
            // Code to chase player
            ChasePlayer();
        }
        else
        {
            // Stop chasing player 
            StopChasingPlayer();
        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            StopChasingPlayer();
        }
    }

    void ChasePlayer()
    {
        if (transform.position.x < player.position.x) // Enemy is to the left side of the player move right  
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(0.6975977f, 0.6975977f);
        }
        else // Enemy is to the right side of the player move left  
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-0.6975977f, 0.6975977f);
        }
    }

    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }

    void PlayerDie()
    {
        if (die)
        {
            playerAnimation.SetTrigger("Die");
            gameObject.SetActive(false);
        }
    }
}
