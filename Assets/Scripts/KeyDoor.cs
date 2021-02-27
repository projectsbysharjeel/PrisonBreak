using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public Vector3 pos1; // position start
    public Vector3 pos2; // position end
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OpenDoor()
    {
        //gameObject.SetActive(false);
        SlideDoor();
    }

    private void SlideDoor()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(1f, 1f));
    }
}
