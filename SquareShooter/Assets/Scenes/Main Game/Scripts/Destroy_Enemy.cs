using UnityEngine;
using System.Collections;

public class Destroy_Enemy : MonoBehaviour
{

    public GameObject explosion;
    public GameObject shooterExplosion;


    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject temp = GameObject.Find("Player");
        Player player = temp.GetComponent<Player>();
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "ShooterEnemy")
        {
            player.score += 5;
            if (player.score % 20 == 0)
            {
                player.fireRate = player.fireRate - 0.05f;
                if (player.fireRate < 0.1)
                {
                    player.fireRate = 0.1f;
                }
            }
            if (collision.gameObject.tag == "Enemy")
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            else if (collision.gameObject.tag == "ShooterEnemy")
            {
                Instantiate(shooterExplosion, transform.position, transform.rotation);
            }
            Destroy(collision.gameObject);
        }
        player.txt_score.text = "Score :" + player.score;
    }
}
