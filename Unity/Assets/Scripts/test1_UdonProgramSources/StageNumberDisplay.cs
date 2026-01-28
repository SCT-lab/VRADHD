
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class StageNumberDisplay : UdonSharpBehaviour
{
    public Scoreboard scoreBoard;
    public TextMeshProUGUI StageNumberDisplayText;

    void Update()
    {
        StageNumberDisplayText.text = scoreBoard.stageNumber.ToString() + " / 7";
    }
}
