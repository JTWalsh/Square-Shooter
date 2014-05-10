using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{

    public Texture backgroundTexture;

    public bool isCredit = false;
    public bool isStart = false;
    public bool isBack = false;
    public bool isQuit = false;
    public bool isInstructions = false;

    public GameObject credit;
    public GameObject instructions;
    public GameObject start;
    public GameObject title;
    public GameObject creditInfo;
    public GameObject back;
    public GameObject wasd;
    public GameObject arrows;


    void OnMouseEnter()
    {
        guiText.color = Color.green;
    }

    void OnMouseExit()
    {
        guiText.color = Color.black;
    }

    void OnMouseUp()
    {
        if (isCredit == true)
        {
            iTween.MoveTo(credit, iTween.Hash("y", 2, "easeType", "easeInExpo", "time", 1.5));
            iTween.MoveTo(start, iTween.Hash("y", 2, "easeType", "easeInExpo", "time", 1.5));
            iTween.MoveTo(title, iTween.Hash("y", 2, "easeType", "easeInExpo", "time", 1.5));
            iTween.MoveTo(instructions, iTween.Hash("y", 2, "easeType", "easeInExpo", "time", 1.5));
            iTween.MoveTo(creditInfo, iTween.Hash("y", .5, "easeType", "easeOutExpo", "time", 5));
            iTween.MoveTo(back, iTween.Hash("y", .2, "easeType", "easeOutExpo", "time", 5));
        }
        if (isInstructions == true)
        {
            iTween.MoveTo(credit, iTween.Hash("y", 2, "easeType", "easeInExpo", "time", 1.5));
            iTween.MoveTo(start, iTween.Hash("y", 2, "easeType", "easeInExpo", "time", 1.5));
            iTween.MoveTo(title, iTween.Hash("y", 2, "easeType", "easeInExpo", "time", 1.5));
            iTween.MoveTo(instructions, iTween.Hash("y", 2, "easeType", "easeInExpo", "time", 1.5));
            iTween.MoveTo(wasd, iTween.Hash("y", .7, "easeType", "easeOutExpo", "time", 5));
            iTween.MoveTo(arrows, iTween.Hash("y", .5, "easeType", "easeOutExpo", "time", 5));
            iTween.MoveTo(back, iTween.Hash("y", .2, "easeType", "easeOutExpo", "time", 5));
        }
        if (isBack == true)
        {
            iTween.MoveTo(credit, iTween.Hash("y", .1, "easeType", "spring", "time", 1.5));
            iTween.MoveTo(start, iTween.Hash("y", .3, "easeType", "spring", "time", 1.5));
            iTween.MoveTo(title, iTween.Hash("y", .8, "easeType", "spring", "time", 1.5));
            iTween.MoveTo(instructions, iTween.Hash("y", .2, "easeType", "spring", "time", 1.5));
            iTween.MoveTo(creditInfo, iTween.Hash("y", -2, "easeType", "easeOutExpo", "time", 5));
            iTween.MoveTo(wasd, iTween.Hash("y", -2, "easeType", "easeOutExpo", "time", 5));
            iTween.MoveTo(arrows, iTween.Hash("y", -2, "easeType", "easeOutExpo", "time", 5));
            iTween.MoveTo(back, iTween.Hash("y", -2, "easeType", "easeOutExpo", "time", 5));
        }
        if (isStart == true)
        {
            Application.LoadLevel("GameScreen");
        }

        if (isQuit == true)
        {
            Time.timeScale = 1;
            Application.LoadLevel("Main Menu");
        }
    }

}
