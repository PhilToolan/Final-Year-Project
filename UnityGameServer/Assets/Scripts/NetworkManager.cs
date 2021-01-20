using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager instance;

    public GameObject playerPrefab;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object");
            Destroy(this);
        }
    }

    private void Start()
    {
        //Ensure the frame rate of the server is the same as the tick rate to reduce CPU consumption
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;

        //Ensure port stays open after closing the application
        #if UNITY_EDITOR
        Debug.Log("Build the project to start server!!");
        #else
        Server.Start(50, 26950);
        #endif    
    }

    public Player InstantiatePlayer()
    {
        return Instantiate(playerPrefab, Vector3.zero, Quaternion.identity).GetComponent<Player>();
    }
}
