using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f; // movement speed
    public float jumpSpeed = 5f; // jump speed
    public float HighJumpSpeed = 18f; // High jump Speed
    private float movement = 0f; // Player movement 
    private Rigidbody2D rigidBody;

    // Ground check for jumping 
    public Transform groundCheckPoint;
    public float groundCheckRadius; 
    public LayerMask groundLayer;
    private bool isTouchingGround;
    
    public Vector3 respawnPoint;

    public LevelManager gameLevelManager;
    public WeaponScript myWeapon;
    public Lifeline newLife;
    
    private bool attack;
    private bool die = false;

    // Animation Control
    private Animator playerAnimation;

    // HUD elements
    public GameObject heart1, heart2, heart3;
    public static int health = 3;

    public GameObject lifeline;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // Accessing the rigidbody component 
        playerAnimation = GetComponent<Animator>(); // Accessing the animator to control animations 
        respawnPoint = transform.position; // Set respawn position to starting point 
        gameLevelManager = FindObjectOfType<LevelManager>(); // Accessing Level manager class
        myWeapon = FindObjectOfType<WeaponScript>(); // Accessing weapon script class
        newLife = FindObjectOfType<Lifeline>(); // Accessing lifeline script class
    }

    void Update()
    {
        HandleInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        movement = Input.GetAxis("Horizontal"); // move left and right
        if (movement > 0f) // If right key pressed, move right
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(0.6836291f, 0.6836291f); //  Changing sprite direction when moving right 
        }
        else if (movement < 0) // if left key pressed, move left
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(-0.6836291f, 0.6836291f); // Changing sprite direction when moving left 
        }
        else // if none pressed, stay still
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, HighJumpSpeed);
        }

        // Player Animation
        playerAnimation.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        playerAnimation.SetBool("OnGround", isTouchingGround);

        // Check Attack
        HandleAttacks();
        attack = false;

        if (newLife.lifelinePicked)
        {
            health += 1;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDetector")
        {
            die = true;
            PlayerDie();
        }
        else if (other.tag == "Spikes")
        {
            die = true;
            PlayerDie();
        }
        else if (other.tag == "Lava")
        {
            die = true;
            PlayerDie();
        }

    }

    private void HandleAttacks()
    {
        if (attack)
        {
            playerAnimation.SetTrigger("Attack");
        }
    }

    public void PlayerDie()
    {
        if (die)
        {
            playerAnimation.SetTrigger("Die");
            health -= 1;

            // HUD Elements update
            switch (health)
            {
                case 3:
                    break;
                case 2:
                    heart3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.4f);
                    break;
                case 1:
                    heart2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.4f);
                    heart3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.4f);
                    break;
                case 0:
                    heart1.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.4f);
                    heart2.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.4f);
                    heart3.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.4f);
                    RestartGame();
                    break;
            }

            gameLevelManager.Respawn(); // Calling function from LevelManager script 
        }
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && (myWeapon.weaponPicked))
        {
            attack = true;
        }
    }

    public void RestartGame()
    {
        StartCoroutine("Reset");
    }

    public IEnumerator Reset()
    {
        yield return new WaitForSeconds(1); // Wait for 2 seconds to reset the game 
        health = 3;
        SceneManager.LoadScene(4);
    }

}
