using UnityEngine;
using System.Collections;

public class TweenMovement : MonoBehaviour
{

    public float finalLocation;
    public float time;

    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("y", finalLocation, "easeType", "spring", "time", time));
    }
}