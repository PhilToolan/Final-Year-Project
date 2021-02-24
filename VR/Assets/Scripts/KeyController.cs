using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{

    Transform key;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.FindGameObjectWithTag("Key").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            door.SetActive(true);
        }
    }
}
