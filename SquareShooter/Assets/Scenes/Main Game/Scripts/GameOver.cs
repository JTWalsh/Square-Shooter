using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{

    public GameObject gameOver;


    // Update is called once per frame
    void Update()
    {
        GameObject tst = GameObject.Find("Player");
        Player player = tst.GetComponent<Player>();
        int lives = player.lives;
        if (lives == 0)
        {
            iTween.MoveTo(gameOver, iTween.Hash("y", .5, "easeType", "spring", "time", 1.5));
        }
    }

}
