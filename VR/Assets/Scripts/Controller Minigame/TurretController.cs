using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {
    public bool shooting = false;
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float rotSpeed = 180; // In degrees per second

    public int fireRate = 2;

    public GameObject hackgame;
    public GameObject controllerplayer;

    Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}

    private void OnEnable()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            shooting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            shooting = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Player")
        {
            Vector3 toPlayer = other.transform.position - transform.position;

            
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                Quaternion.LookRotation(toPlayer)
                , rotSpeed * Time.deltaTime
                );
            
            /*
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(toPlayer)
                , Time.deltaTime
                );                
                */
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


    void OnDestroy()
    {
        hackgame.SetActive(false);
        controllerplayer.SetActive(true);
    }


}
