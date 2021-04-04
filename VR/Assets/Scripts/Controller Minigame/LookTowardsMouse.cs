using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardsMouse : MonoBehaviour
{
    public Camera camera2D;
    public GameObject bulletPrefab;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotation of "target"
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 38.0f;

        Vector3 objectPos = camera2D.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));


        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab
                    , spawnPoint.position
                    , this.transform.rotation
                    );
        }

    }
}
