
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Reset : UdonSharpBehaviour
{
    public Scoreboard scoreboard;
    public BullwhipIndex BWEitem;
    private int resetCounter = 0;

    public override void Interact()
    {
        resetCounter = resetCounter + 1;
        if(resetCounter == 3)
        {
            scoreboard.ResetStage();
            BWEitem.ResetArrays();
            resetCounter = 0;
        }

    }
}
