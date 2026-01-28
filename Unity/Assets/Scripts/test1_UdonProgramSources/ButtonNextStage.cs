using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;
using UnityEngine.UI;

public class ButtonNextStage : UdonSharpBehaviour
{
    public Scoreboard scoreBoard;
    public GameObject BWEMenu;



    public override void Interact()
    {
        if(!BWEMenu.activeSelf)
        {
            scoreBoard.NextStage();
            scoreBoard.inputUser = false;

        }
    }
}
