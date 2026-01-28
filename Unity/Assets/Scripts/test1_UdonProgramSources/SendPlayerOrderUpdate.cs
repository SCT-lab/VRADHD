
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SendPlayerOrderUpdate : UdonSharpBehaviour
{
    public PlayerOrderUpdate itemBasket;
    public Scoreboard scoreBoard;

    public override void Interact()
    {
        if (scoreBoard.inputUser == false)
        {
            int temp = itemBasket.orderAmount;
            if (itemBasket.orderAmount > 51)
            {
                scoreBoard.PlayerOrder = 50;

                if(scoreBoard.InvMartha < scoreBoard.PlayerOrder)
                {
                    scoreBoard.PlayerOrder = scoreBoard.InvMartha;
                }              
                
            }
            else
            {
                scoreBoard.PlayerOrder = itemBasket.orderAmount;
                
                if(scoreBoard.InvMartha < scoreBoard.PlayerOrder)
                {
                    scoreBoard.PlayerOrder = scoreBoard.InvMartha;
                }   
            }
            itemBasket.orderAmount = 0;
            
            scoreBoard.WasteUpdate();
            scoreBoard.CostInventoryUpdate();
            scoreBoard.RevenueUpdate();
            scoreBoard.InventoryUpdate();
            scoreBoard.updateText();
            scoreBoard.inputUser = true;
            
        }
        
        
    }
}
