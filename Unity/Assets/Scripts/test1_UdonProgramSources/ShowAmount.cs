
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class ShowAmount : UdonSharpBehaviour
{
    public PlayerOrderUpdate objectPlayerOrder;
    public TextMeshProUGUI PhaseText;

    public void Update()
    {
        updateTextOrderAmount();
    }
    public void updateTextOrderAmount()
    {
        PhaseText.text = objectPlayerOrder.orderAmount.ToString();
    }
}
