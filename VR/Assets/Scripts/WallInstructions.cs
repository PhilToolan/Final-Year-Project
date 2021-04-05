using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallInstructions : MonoBehaviour
{

    public GameObject wallmenu;
    public Text wallText;
    [SerializeField] private string message = "You need more access points!";
    public int accessPoints = 1;
    public int requiredPoints = 3;
    [SerializeField] private string curMessage;
    public Animator animator;

    void OnMouseDown()
    {
        DisplayMessage();
        wallmenu.SetActive(true);
    }

    void Update()
    {

        if (accessPoints == requiredPoints)
        {
            message = curMessage;
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

    public void Close()
    {
        animator.SetTrigger("Close");
    }


}
