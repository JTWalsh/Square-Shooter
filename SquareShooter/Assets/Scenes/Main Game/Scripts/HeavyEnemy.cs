using UnityEngine;
using System.Collections;

public class HeavyEnemy : MonoBehaviour
{

    public float step = 10f;
    private Transform player;
    public int health = 3;

    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        player = go.transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, player.position, step * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1;
            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
        Debug.Log("Heavy health = " + health);
    }
}
