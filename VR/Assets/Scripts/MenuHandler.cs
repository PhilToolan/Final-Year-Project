using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

    [SerializeField] private string tutorial;
    [SerializeField] private string mission1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(tutorial);
    }

    public void LoadMission()
    {
        SceneManager.LoadScene(mission1);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
