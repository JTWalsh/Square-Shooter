using UnityEngine;
using System.Collections;

public class Ready : MonoBehaviour {

    public float finalLocation;
    public float finalLocation2;
    public float time;

    IEnumerator Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("y", finalLocation, "easeType", "spring", "time", time));
        yield return new WaitForSeconds(5);
        iTween.MoveTo(gameObject, iTween.Hash("y", finalLocation2, "easeType", "spring", "time", time));
    }
}
