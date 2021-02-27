using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScenes : MonoBehaviour
{
    [SerializeField] private string newLevel;
    public KeyScript myKey;

    void Start()
    {
        myKey = FindObjectOfType<KeyScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && (myKey.keyPicked))
        {
            SceneManager.LoadScene(newLevel);
        }
    }
}
