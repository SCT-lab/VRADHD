
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ButtonPressedSound : UdonSharpBehaviour
{
    public AudioSource buttonPressedSound;

    public void Interact()
    {
        if (buttonPressedSound != null)
        {
            buttonPressedSound.Play();
        }
    }

}
