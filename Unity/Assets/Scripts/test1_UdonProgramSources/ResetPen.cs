
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ResetPen : UdonSharpBehaviour
{

    public VRC.SDK3.Components.VRCObjectSync objectSync;

    public override void Interact()
    {
        objectSync.Respawn();
    }
}
