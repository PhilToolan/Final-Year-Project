using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallInteractionButton : MonoBehaviour
{

    public GameObject wallmenu;
    public Text wallText;
    [SerializeField] private string message;
    public int accessPoints = 1;

    void OnMouseDown()
    {
        DisplayMessage();
        wallmenu.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            wallmenu.SetActive(false);
        }

        if (accessPoints <= 1)
        {
            message = "Need more access points!";
        }
        if (accessPoints > 1)
        {
            message = "I love YOU ";
        }
    }

    void DisplayMessage()
    {
        wallText.text = message;
    }

    public void IncreasePoints()
    {
        accessPoints += 1;
    }

}
