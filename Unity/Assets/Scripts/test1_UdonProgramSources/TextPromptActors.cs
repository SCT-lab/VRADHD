
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class TextPromptActors : UdonSharpBehaviour
{
    public Scoreboard scoreBoard;
    public BullwhipIndex BWEitem; 
    public TextMeshProUGUI textPrompt;
    public GameObject textCanvas;
    public string actor;
    float timer1 = 7f;
    bool reportActive1 = false;
    public AudioSource audioPhase1;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioSource[] audioPhases;

    public override void Interact()
    {
        if(scoreBoard.phase == "Phase 2: communication")
        {
            if(!reportActive1)
            {
                CheckAudioSources();
                audioPhase1.PlayOneShot(clip2);
                textCanvas.SetActive(true);
                reportActive1 = true;


                if(actor == "Josh")
                {
                    textPrompt.text = "Hi! I'm expecting an order of: <color=green><b>" + scoreBoard.averageDemandManufacturer.ToString($"F{0}") + "</b></color> and my inventory is: <color=green><b>" + scoreBoard.InvJosh + "</b></color>";
                    scoreBoard.InvJoshOn = true;
                    scoreBoard.TransitManufacturerEnable = true;
                }

                if(actor == "Martha")
                {
                    var tempEOQ = 5 + Mathf.Sqrt((2 * scoreBoard.averageDemandPlayer * 5) / 1);
                    var temp1 = (int)tempEOQ;
                    textPrompt.text = "Hi! I'm expecting an order of: <color=green><b>" + temp1.ToString($"F{0}") + "</b></color> and my inventory is: <color=green><b>" + scoreBoard.InvMartha + "</b></color>";
                    scoreBoard.OrderMarthaEnable = true;
                    scoreBoard.InvMarthaOn = true;
                    
                }
                
                if(actor == "Megan")
                {   
                    var tempEOQ = 5 + Mathf.Sqrt((2 * scoreBoard.averageDemandDistributor * 5) / 1);
                    var temp1 = (int)tempEOQ;
                    textPrompt.text = "Hi! I'm expecting an order of: <color=green><b>" + temp1.ToString($"F{0}") + "</b></color> and my inventory is: <color=green><b>" + scoreBoard.InvMegan + "</b></color>";
                    scoreBoard.OrderMeganEnable = true;
                    scoreBoard.TransitMeganEnable = true;
                    scoreBoard.InvMeganOn = true;
                }

                if(actor == "Joe")
                {
                    // TODO
                    var tempAmount = 0;
                    if(scoreBoard.stageNumber == 1)
                    {
                        tempAmount = 8;
                    }
                    if(scoreBoard.stageNumber == 2)
                    {
                        tempAmount = 12;
                    }
                    if(scoreBoard.stageNumber == 3)
                    {
                        tempAmount = 8;
                    }
                    if(scoreBoard.stageNumber == 4)
                    {
                        tempAmount = 8;
                    }
                    if(scoreBoard.stageNumber == 5)
                    {
                        tempAmount = 5;
                    }
                    if(scoreBoard.stageNumber == 6)
                    {
                        tempAmount = 3;
                    }
                    textPrompt.text = "Hi! I'm thinking of ordering roughly this amount next round: <color=green><b>" + tempAmount + "</b></color>";
                    Vector3 playerPosition = Networking.LocalPlayer.GetPosition();
                    transform.LookAt(playerPosition);

                }
                
            }
            else
            {
                reportActive1 = false;
                textCanvas.SetActive(false);
                timer1 = 7f;
            }
            
            // Hi! I'm expecting an order of 15 and my inventory is 50.
        }
        else
        {
            if(!reportActive1)
            {
                CheckAudioSources();
                audioPhase1.PlayOneShot(clip1);
                textCanvas.SetActive(true);
                textPrompt.text = "I'm sorry. We cannot communicate right now. Try again next phase!";
                reportActive1 = true;

                if(actor == "Joe")
                {
                Vector3 playerPosition = Networking.LocalPlayer.GetPosition();
                transform.LookAt(playerPosition);
                }

            }
            else
            {
                reportActive1 = false;
                textCanvas.SetActive(false);
                timer1 = 7f;
            }
            
        }
    }

    private void Update()
    {
        if(reportActive1)
        {
            timer1 -= Time.deltaTime;

            if(timer1 < 0f)
            {
                reportActive1 = false;
                textCanvas.SetActive(false);
                timer1 = 10f;
            }
        }
    }

    private void CheckAudioSources()
    {
        foreach(var audioSource in audioPhases)
        {
            if(audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
