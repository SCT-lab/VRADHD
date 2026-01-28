
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PracticeRoundEnable : UdonSharpBehaviour
{
    public float timer = 305f;
    public GameObject videoPlayer;
    public GameObject practiceRoundMenu;
    public GameObject enableNotepad;
    public GameObject readyButton;

    bool reportActive = false;
    public bool readyButtonBool = false;
    
    bool hasExecuted = false;

    private void Update()
    {
        if (!hasExecuted && videoPlayer.activeSelf)
        {
            reportActive = true;
        }

        if (reportActive)
        {
            
            readyButton.SetActive(true);

            if (readyButtonBool)
            {
                videoPlayer.SetActive(false);
                practiceRoundMenu.SetActive(true);
                enableNotepad.SetActive(true);
                readyButton.SetActive(false);
                reportActive = false;
                hasExecuted = true;
            }
        }
    }
}
