using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITank : MonoBehaviour
{
    public int numwaypoints = 5;
    public float radius = 10;

    public int current = 0;
    public float speed = 10;
    public List<Vector3> waypoints = new List<Vector3>();
    public Transform player;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public int fireRate = 2;

    bool shooting = false;

    void Start()
    {
        MakeWaypoints();
    }

    void MakeWaypoints()
    {
        waypoints.Clear();
        float thetaInc = (Mathf.PI * 2) / numwaypoints;
        for (int i = 0; i < numwaypoints; i++)
        {
            float theta = i * thetaInc;
            Vector3 pos = new Vector3(Mathf.Sin(theta) * radius, 0, Mathf.Cos(theta) * radius);
            pos = transform.TransformPoint(pos);
            waypoints.Add(pos);
        }
    }

    public void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            MakeWaypoints();
            for (int i = 0; i < waypoints.Count; i++)
            {
                Gizmos.DrawWireSphere(waypoints[i], 2);
            }
        }
    }
    void Update()
    {
        Vector3 toTarget = waypoints[current] - transform.position;
        Debug.Log("To waypoint: " + toTarget.magnitude);
        if (toTarget.magnitude < 1)
        {
            current = (current + 1) % waypoints.Count;
        }
        toTarget.Normalize();
        //transform.forward = toTarget;
        
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(toTarget), Time.deltaTime * 5.0f);
        
        transform.Translate(toTarget * speed * Time.deltaTime, Space.World);


        //transform.position = Vector3.Lerp(transform.position, waypoints[current], Time.deltaTime);

        Vector3 toPlayer = player.position - transform.position;
        if (Vector3.Dot(transform.forward, toPlayer) < 0)
        {
            Debug.Log("Player is behind");
        }
        else
        {
            Debug.Log("Player is in front");
        }
        float angle = Mathf.Acos(Vector3.Dot(transform.forward, toPlayer) / toPlayer.magnitude) * Mathf.Rad2Deg;
        Debug.Log("Angle to player 1: " + angle);
        
        float a = Vector3.Angle(transform.forward, toPlayer);
        
        if (angle < 45)
        {
            Debug.Log("Player is inside the FOV");
            shooting = true;
        }
        else
        {
            Debug.Log("Player is outside the FOV");
            shooting = false;
        }
    }

    void OnEnable()
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
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Collision");
            ExplodeMyParts();
        }
    }

    private void ExplodeMyParts()
    {
        ParticleSystem exp = GetComponent<ParticleSystem>();
        exp.Play();
        foreach (Transform t in this.GetComponentsInChildren<Transform>())
        {
            Rigidbody rb = t.gameObject.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = t.gameObject.AddComponent<Rigidbody>();
            }
            rb.useGravity = true;
            rb.isKinematic = false;
            Vector3 v = new Vector3(
                Random.Range(-5, 5)
                , Random.Range(5, 10)
                , Random.Range(-5, 5)
                );
            rb.velocity = v;
        }
        Invoke("Sink", 2);
        Destroy(this.gameObject, 3);
        Destroy(transform.GetChild(0), 4); // Destroy the other part of the model
    }

    void Sink()
    {
        GetComponent<Collider>().enabled = false;
        transform.GetChild(0).GetComponent<Collider>().enabled = false;
    }
}
