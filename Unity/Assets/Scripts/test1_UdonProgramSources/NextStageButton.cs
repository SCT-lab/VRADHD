
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class NextStageButton : UdonSharpBehaviour
{
    public Scoreboard scoreBoard;
    public GameObject menuItem;
    public GameObject enableGeneralMenu;
    public GameObject charactersEnable;
    public GameObject appleEnable;
    public GameObject blackboardToggleEnable;
    public GameObject textEnable;
    public GameObject[] laptopArray;
    public BullwhipIndex itemBWE;


    public override void Interact()
    {
        scoreBoard.currentStage = StageGame.Stage8;
        scoreBoard.UpdateScoreboard();
        scoreBoard.scoreBoardItem.SetActive(true);
        menuItem.SetActive(false);
        enableGeneralMenu.SetActive(true);
        scoreBoard.inputUser = false;
        itemBWE.ResetArrays();

        if(charactersEnable.activeSelf == false)
        {
            charactersEnable.SetActive(true);
            appleEnable.SetActive(true);
            blackboardToggleEnable.SetActive(true);
            textEnable.SetActive(true);

            foreach(var item in laptopArray)
            {
                item.SetActive(true);
            }
        }
    }
}

