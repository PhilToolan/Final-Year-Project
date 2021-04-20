using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextMission : MonoBehaviour
{
    [SerializeField] private string mission;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(mission);
    }

    public void Next()
    {
        SceneManager.LoadScene(mission);
    }
}
