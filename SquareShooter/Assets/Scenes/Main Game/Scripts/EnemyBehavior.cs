using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{
    public float maxSpeed;
    Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
        int randomX = Random.Range(-4, 4);
        int randomY = Random.Range(-4, 4);
        if (randomX == 0)
        {
            randomX = 1;
        }
        if (randomY == 0)
        {
            randomY = 1;
        }
        rigidbody2D.velocity = new Vector2(randomX, randomY);
    }

    void Update()
    {
        if (transform.position.y < -3.59)
        {
            rigidbody2D.AddForce(transform.up * 1 * Time.deltaTime);
        }
        else if (transform.position.y > 3.59)
        {
            rigidbody2D.AddForce(-transform.up * 1 * Time.deltaTime);
        }
        else if (transform.position.x < -3.59)
        {
            rigidbody2D.AddForce(transform.right * 1 * Time.deltaTime);
        }
        else if (transform.position.x > 3.59)
        {
            rigidbody2D.AddForce(-transform.right * 1 * Time.deltaTime);
        }
        if (rigidbody2D.velocity.magnitude > maxSpeed)
        {
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxSpeed;
        }
    }
}
