using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifeline : MonoBehaviour
{
    public bool lifelinePicked = false;
    public GameObject lifelineHUD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Player"))
        {
            Destroy(gameObject);
            lifelineHUD.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            lifelinePicked = true;
        }
    }
}
