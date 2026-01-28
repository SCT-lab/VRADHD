
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Phase1Skip : UdonSharpBehaviour
{
    public Scoreboard scoreBoard;
    public GameObject item;
    public GameObject item2;
    public GameObject menu;
    public GameObject NoThanksButton;
    public GameObject itemNSB;
    private int resetCounter = 0;

    public override void Interact()
    {
        resetCounter = resetCounter + 1;
        if(resetCounter == 2)
        {
            itemNSB.SetActive(true);
                //menu.SetActive(true);
            item.SetActive(false);
        }
    }
}
