using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCharacter : MonoBehaviour
{
    public float speed = 5;
//    public GameObject bulletPrefab;
//    public Transform spawnPoint;
    public bool shooting = false;
    public int fireRate = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

/*    private void OnEnable()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            if (shooting)
            {
                GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab
                    , spawnPoint.position
                    , transform.rotation
                    );

            }
            yield return new WaitForSeconds(1.0f / (float)fireRate);
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        Move();

/*        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab
                    , spawnPoint.position
                    , transform.rotation
                    );
        }
*/

    }

    void Move()
    {
        if (Input.GetKey("up"))//Press up arrow key to move forward on the Z AXIS
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("down"))//Press down arrow key to move back on the Z AXIS
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey("left"))//Press left arrow key to move left on the Z AXIS
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("right"))//Press right arrow key to move right on the Z AXIS
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }


}
