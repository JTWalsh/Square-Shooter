using UnityEngine;
using System.Collections;

public class Enemy_Shoot : MonoBehaviour
{

    public float fireRate;
    public float nextFire = 1;

    public GameObject bullet;

    Transform enemyBullet;
    Transform playerPosition;

    void Awake()
    {
        if (!playerPosition)
        {
            playerPosition = GameObject.FindWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPosition)
        {
            if (Time.time >= nextFire)
            {
                nextFire = Time.time + fireRate;
                CreateBullet();
            }
        }
    }

    void CreateBullet()
    {
        // Creates a new instance of the bullet
        Instantiate(bullet, transform.position + (playerPosition.position - transform.position).normalized, transform.rotation);
    }
}
