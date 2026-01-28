
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class ExtraTime : UdonSharpBehaviour
{
    public GameObject objectPractice;
    public TextMeshProUGUI timerValueText;
    public string textCheck;
    
    private void Update()
    {
        PracticeRoundEnable enablePracticeScript = objectPractice.GetComponent<PracticeRoundEnable>();
        timerValueText.text = "Ready";
    }

    public override void Interact()
    {
        PracticeRoundEnable enablePracticeScript = objectPractice.GetComponent<PracticeRoundEnable>();
        if(textCheck == "green")
        {
            enablePracticeScript.readyButtonBool = true;
            
            
        }
    }
}
