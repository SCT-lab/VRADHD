
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class DisableFullInformation : UdonSharpBehaviour
{
    private bool enabled = true;
    public GameObject[] itemsArray;
    public GameObject[] tmpArray;
    public Renderer scoreBoardMaterial;
    public Renderer button;
    public Material sb1;
    public Material sb2;

    public Material green;
    public Material red;

    public override void Interact()
    {
        if(enabled)
        {
            for(int i = 0; i < 3; i++)
            {
                itemsArray[i].SetActive(false);
            }

            for(int i = 0; i < 11; i++)
            {
                tmpArray[i].SetActive(false);
            }

            scoreBoardMaterial.material = sb2;
            button.material = red;
            enabled = false;
        }
        else
        {
            for(int i = 0; i < 3; i++)
            {
                itemsArray[i].SetActive(true);
            }

            for(int i = 0; i < 11; i++)
            {
                tmpArray[i].SetActive(true);
            }

            scoreBoardMaterial.material = sb1;
            button.material = green;
            enabled = true;
        }
    }
}
