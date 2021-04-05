using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenButton : MonoBehaviour
{

    public GameObject screenmenu;
    public Animator animator;

    void OnMouseDown()
    {
        screenmenu.SetActive(true);
    }

    public void Close()
    {
        animator.SetTrigger("Close");
    }


}
