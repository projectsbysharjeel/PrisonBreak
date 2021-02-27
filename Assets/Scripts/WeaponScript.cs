using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponScript : MonoBehaviour
{
    public bool weaponPicked = false;
    public GameObject weaponHUD;
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
            weaponHUD.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            weaponPicked = true;
        }
    }
}
