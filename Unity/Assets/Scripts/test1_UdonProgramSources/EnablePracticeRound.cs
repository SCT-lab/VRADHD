
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class EnablePracticeRound : UdonSharpBehaviour
{
    public Scoreboard scoreBoard;
    public GameObject item;
    public GameObject item2;
    public GameObject menu;
    public GameObject NoThanksButton;

    public override void Interact()
    {
        if (gameObject == NoThanksButton && NoThanksButton.activeSelf)
        {
            scoreBoard.PREnabled = false;
            menu.SetActive(true);
            item.SetActive(false);
        }
        else
        {
            scoreBoard.PREnabled = true;
            menu.SetActive(true);
            item.SetActive(false);
        }
        
    }
}
