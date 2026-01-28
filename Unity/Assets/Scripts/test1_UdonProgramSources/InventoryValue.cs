using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;
using UnityEngine.UI;

public class InventoryValue : UdonSharpBehaviour
{
    public Scoreboard scoreboard;
    public TextMeshProUGUI InvTextBox;

    void Update()
    {
        InvTextBox.text = "" + scoreboard.inventory.ToString();
    }
}
