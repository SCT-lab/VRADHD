
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class OrderReceivedMenu : UdonSharpBehaviour
{
    public Scoreboard scoreBoard;
    public GameObject greenPlane;
    public GameObject redPlane;
    public PlayerOrderUpdate itemBasket;
    public TextMeshProUGUI OrderAmountText;

    void Update()
    {
        if (scoreBoard.inputUser)
        {
            greenPlane.SetActive(true);
            redPlane.SetActive(false);
            OrderAmountText.text = scoreBoard.PlayerOrder.ToString();
        }
        if (!scoreBoard.inputUser)
        {
            greenPlane.SetActive(false);
            redPlane.SetActive(true);
            OrderAmountText.text = itemBasket.orderAmount.ToString();
        }
    }
}
