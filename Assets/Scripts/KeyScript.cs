using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour
{
    public bool keyPicked = false;
    public KeyDoor myKey;
    public GameObject keyHUD;
    // Start is called before the first frame update
    void Start()
    {
        myKey = FindObjectOfType<KeyDoor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        keyHUD.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        keyPicked = true;

        if (keyPicked)
        {
            myKey.OpenDoor();
        }
    }
}
