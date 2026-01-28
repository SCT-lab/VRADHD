
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class UpdateTextFirstTime : UdonSharpBehaviour
{
    public Scoreboard scoreboard;

    public override void Interact()
    {
        scoreboard.updateText();
        scoreboard.ResetStage();
    }
}
