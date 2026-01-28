
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class VolumeIcon : UdonSharpBehaviour
{
    public TextMeshProUGUI textBox;

    void Start()
    {
        textBox.text = "🔊";
    }
}
