using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenButton : MonoBehaviour
{

    public GameObject screenmenu;

    void OnMouseDown()
    {
        screenmenu.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            screenmenu.SetActive(false);
        }
    }

}
