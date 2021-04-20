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
    public int requiredPoints;
    public string curMessage;
    public GameObject realWall;
    public Animator animator;
    public GameObject hackmenu;
    public bool hacked;

    void OnMouseDown()
    {
        DisplayMessage();
        if (accessPoints <= requiredPoints)
        {
            wallmenu.SetActive(true);
        }
        if (accessPoints > requiredPoints)
        {
            Destroy(realWall.gameObject);
            Destroy(this.gameObject);
        }
    }

    void Update()
    {

        if (accessPoints <= requiredPoints)
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

    void OnDisable()
    {
        if (hacked)
        {
            hackmenu.SetActive(true);
        }
        
    }

}
