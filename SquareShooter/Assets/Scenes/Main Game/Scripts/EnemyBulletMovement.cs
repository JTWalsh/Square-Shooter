using UnityEngine;
using System.Collections;

public class EnemyBulletMovement : MonoBehaviour
{

    public float step = 10f;
    private Transform player;
    private Vector3 distance;

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        player = go.transform;
        distance = player.position - this.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    //Update is called once per frame
    void Update()
    {
        this.transform.Translate(distance * step * Time.deltaTime);
        //this.transform.position = Vector3.MoveTowards(this.transform.position, player.position, step * Time.deltaTime);
    }
}