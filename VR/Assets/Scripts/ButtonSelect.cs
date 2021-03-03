using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelect : MonoBehaviour
{

    public GameObject door;

    void OnMouseDown()
    {
        door.SetActive(true);
    }

}
