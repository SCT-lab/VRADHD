
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TriggerTextPromptElse : UdonSharpBehaviour
{
    public TextPromptActors textPromptActor;
    public GameObject actorItem;

    public override void Interact()
    {
        TextPromptActors textPromptActor = actorItem.GetComponent<TextPromptActors>();
        textPromptActor.Interact();
    }
}
