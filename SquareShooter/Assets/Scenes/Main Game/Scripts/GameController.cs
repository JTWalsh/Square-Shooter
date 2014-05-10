using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public GameObject enemy;
    public GameObject heavyEnemy;
    public GameObject shooterEnemy;
    public Vector3 spawnLocation;
    private int enemyCount = 0;
    public float spawnWait;
    public float startWait;
    public Transform player;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        GameObject temp = GameObject.Find("Player");
        Player tempPlayer = temp.GetComponent<Player>();
        yield return new WaitForSeconds(startWait);
        while (tempPlayer.lives != 0)
        {
            if (enemyCount % 5 == 0 && enemyCount != 0)
            {
                spawnWait -= 0.025f;
            }

            Vector3 spawnLocation = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
            float distanceX = spawnLocation.x - player.position.x;
            float distanceY = spawnLocation.y - player.position.y;
            if (Mathf.Abs(distanceX) > 1.5 && Mathf.Abs(distanceY) > 1.5)
            {
                Instantiate(enemy, spawnLocation, Quaternion.identity);
                if (enemyCount > 20 && enemyCount % 5 == 0)
                {
                    Instantiate(shooterEnemy, spawnLocation, Quaternion.identity);
                }
                if (enemyCount > 30 && enemyCount % 10 == 0)
                {
                    Instantiate(heavyEnemy, spawnLocation, Quaternion.identity);
                }
                enemyCount++;
                yield return new WaitForSeconds(spawnWait);

            }

        }
    }
}
