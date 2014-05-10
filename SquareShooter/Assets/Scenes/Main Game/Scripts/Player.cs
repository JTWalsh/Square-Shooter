using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private bool isHit = false;

    public float fireRate;
    public float moveSpeed = 10f;
    private float nextFire;

    public int lives;
    public int score = 0;
    public static int pauseCount = 0;

    public GameObject explosion;
    public GameObject shot;
    public GameObject player;
    public GameObject pause;
    public GameObject quit;

    public AudioClip bullet;


    public GUIText txt_score;
    public GUIText txt_lives;

    private bool invincible = false;

    public Transform shotSpawnUp, shotSpawnDown, shotSpawnLeft, shotSpawnRight, shotSpawnDownLeft, shotSpawnDownRight, shotSpawnUpLeft, shotSpawnUpRight;

    public KeyCode moveUp, moveDown, moveLeft, moveRight, shootUp, shootDown, shootLeft, shootRight;


    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            if (lives > 0 && invincible == false)
            {

                lives--;
                GameObject temp = GameObject.Find("Player");
                Player player = temp.GetComponent<Player>();
                player.txt_lives.text = "Lives :" + player.lives;
                if (lives > 0)
                {
                    invincible = true;
                    isHit = true;
                    yield return new WaitForSeconds(5);
                    invincible = false;
                    isHit = false;
                }
            }
        }
    }


    void Start()
    {
        txt_score.text = "Score: " + score;
        txt_lives.text = "Lives: " + lives;
    }

    void Update()
    {
        Shoot();
        if (isHit == true)
            Instantiate(explosion, transform.position, transform.rotation);
        if (lives == 0)
        {
            Destroy(gameObject);
            Application.LoadLevel("Main Menu");
        }
        if(Input.GetKeyDown("p") && pauseCount == 0)
        {
            Time.timeScale = 0;
            iTween.MoveTo(pause, iTween.Hash("y", .5, "easeType", "spring", "time", 1.5, "ignoretimescale", true));
            iTween.MoveTo(quit, iTween.Hash("y", .3, "easeType", "spring", "time", 1.5, "ignoretimescale", true));
            pauseCount = 1;
        }
        else if (Input.GetKeyDown("p") && pauseCount == 1)
        {
            Time.timeScale = 1;
            iTween.MoveTo(pause, iTween.Hash("y", -1.5, "easeType", "spring", "time", 1.5, "ignoretimescale", true));
            iTween.MoveTo(quit, iTween.Hash("y", -1.5, "easeType", "spring", "time", 1.5, "ignoretimescale", true));
            pauseCount = 0;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(moveRight))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(moveLeft))
        {
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(moveUp))
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(moveDown))
        {
            transform.Translate(-Vector2.up * moveSpeed * Time.deltaTime);
        }

    }

    void Shoot()
    {
        if ((Input.GetKey(shootUp) || Input.GetKey(shootRight) || Input.GetKey(shootLeft) || Input.GetKey(shootDown)) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (Input.GetKey(shootUp) && Input.GetKey(shootRight))
            {
                Instantiate(shot, shotSpawnUpRight.position, shotSpawnUpRight.rotation);
            }
            else if (Input.GetKey(shootDown) && Input.GetKey(shootLeft))
            {
                Instantiate(shot, shotSpawnDownLeft.position, shotSpawnDownLeft.rotation);
            }
            else if (Input.GetKey(shootDown) && Input.GetKey(shootRight))
            {
                Instantiate(shot, shotSpawnDownRight.position, shotSpawnDownRight.rotation);
            }
            else if (Input.GetKey(shootUp) && Input.GetKey(shootLeft))
            {
                Instantiate(shot, shotSpawnUpLeft.position, shotSpawnUpLeft.rotation);
            }
            else if (Input.GetKey(shootUp) && !Input.GetKey(shootDown))
            {
                Instantiate(shot, shotSpawnUp.position, shotSpawnUp.rotation);
            }
            else if (Input.GetKey(shootDown) && !Input.GetKey(shootUp))
            {
                Instantiate(shot, shotSpawnDown.position, shotSpawnDown.rotation);
            }
            else if (Input.GetKey(shootLeft) && !Input.GetKey(shootRight))
            {
                Instantiate(shot, shotSpawnLeft.position, shotSpawnLeft.rotation);
            }
            else if (Input.GetKey(shootRight) && !Input.GetKey(shootLeft))
            {
                Instantiate(shot, shotSpawnRight.position, shotSpawnRight.rotation);
            }
            audio.Play();
        }
    }
}
