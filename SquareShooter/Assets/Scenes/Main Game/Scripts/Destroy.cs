using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
