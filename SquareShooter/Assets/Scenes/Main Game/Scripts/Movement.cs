using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    public float moveSpeed = 10f;
    public KeyCode shootUp, shootDown, shootRight, shootLeft;
    public float fireRate;
    private float nextFire;

    // Update is called once per frame
    void Start()
    {

        if (Input.GetKey(shootUp))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, moveSpeed);
        }
        if (Input.GetKey(shootDown))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -moveSpeed);
        }
        if (Input.GetKey(shootRight))
        {
            rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
        }
        if (Input.GetKey(shootLeft))
        {
            rigidbody2D.velocity = new Vector2(-moveSpeed, rigidbody2D.velocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "ShooterEnemy" || collision.gameObject.tag == "HeavyEnemy")
        {
            Destroy(gameObject);
        }
    }
}
