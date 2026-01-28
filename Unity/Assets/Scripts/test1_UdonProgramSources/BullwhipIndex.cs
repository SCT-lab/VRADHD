
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;
using System.Collections.Generic;

public class BullwhipIndex : UdonSharpBehaviour
{
    public Scoreboard scoreBoard;
    public TextMeshPro BWIndexText;
    public TextMeshPro BWPlayer1Text;
    public TextMeshPro BWPlayer2Text;
    public TextMeshPro BWPlayer3Text;
    public TextMeshPro BWPlayer4Text;
    public TextMeshPro BWPlayer5Text;
    public TextMeshPro BWPlayer6Text;
    public TextMeshPro BWPlayer7Text;

    public TextMeshProUGUI BWHighscoreEUR1;
    public TextMeshProUGUI BWHighscoreEUR2;
    public TextMeshProUGUI BWHighscoreBWE1;
    public TextMeshProUGUI BWHighscoreBWE2;

    public TextMeshPro RevenueText;
    public TextMeshPro RevenueDifference;
    public TextMeshPro TotalRevenue;

    public TextMeshProUGUI OverviewRoundNumber;
    public AudioSource audioPhaseEnd;
    public AudioClip audioClipEnd1;
    public AudioClip audioClipEnd;

    public AudioSource[] soundArray;

    public bool performInitialSetup = false;

    public int BWIndexValue = 0;
    private int arraySize = 7;

    public int[] arrayDemand;
    public int[] arrayPlayer;
    public int[] arrayDistributor;
    public int[] arrayManufacturer;
    
    public float meanDemand;
    public float meanPlayer;
    public float meanDistributor;
    public float meanManufacturer;

    public float varDemand;
    public float varPlayer;
    public float varDistributor;
    public float varManufacturer;

    public float BWEPlayer;
    public float BWEDistributor;
    public float BWEManufacturer;
    
    public float BWETotal1;
    public float BWETotal2;
    public float BWETotal3;
    public float BWETotal4;
    public float BWETotal5;
    public float BWETotal6;
    public float BWETotal7;
    public float BWETotal;

    public float BWEPlayer1;
    public float BWEPlayer2;
    public float BWEPlayer3;
    public float BWEPlayer4;
    public float BWEPlayer5;
    public float BWEPlayer6;
    public float BWEPlayer7;

    public void Start()
    {
        InitialSetup();
        if (scoreBoard.currentStage != StageGame.Sdefault)
        {
            CallUpdateArray();
            CalculationBWE();  
        }
        
    }

    public void InitialSetup()
    {
        if (performInitialSetup == false)
        {
            arrayDemand = new int[arraySize];
            arrayPlayer = new int[arraySize];
            arrayDistributor = new int[arraySize];
            arrayManufacturer = new int[arraySize];
            performInitialSetup = true;

            meanDemand = 0f;
            meanPlayer = 0f;
            meanDistributor = 0f;
            meanManufacturer = 0f;

            varDemand = 0f;
            varPlayer = 0f;
            varDistributor = 0f;
            varManufacturer = 0f;

            BWEPlayer = 0f;
            BWEDistributor = 0f;
            BWEManufacturer = 0f;

            BWETotal1 = 0f;
            BWETotal2 = 0f;
            BWETotal3 = 0f;
            BWETotal4 = 0f;
            BWETotal5 = 0f;
            BWETotal6 = 0f;
            BWETotal7 = 0f;
            BWETotal = 0f;
            
            BWEPlayer1 = 0f;
            BWEPlayer2 = 0f;
            BWEPlayer3 = 0f;
            BWEPlayer4 = 0f;
            BWEPlayer5 = 0f;
            BWEPlayer6 = 0f;
            BWEPlayer7 = 0f;
            
            
        }
        
    }

    void CallUpdateArray()
    {
        UpdateArray(arrayDemand, scoreBoard.JoeOrder, scoreBoard.stageNumber);
        UpdateArray(arrayPlayer, scoreBoard.PlayerOrder, scoreBoard.stageNumber);
        UpdateArray(arrayDistributor, scoreBoard.MarthaOrder, scoreBoard.stageNumber);
        UpdateArray(arrayManufacturer, scoreBoard.MeganOrder, scoreBoard.stageNumber);
        //BWIndexText.text = arrayDemand.ToString();
    }

    private void UpdateArray(int[] arrayType, int newValue, int index)
    {
        // Shift elements in the array to simulate the behavior of List.Add
        if (index > 0)
        {
            arrayType[index - 1] = newValue;
        }
    }

    private void CalculationBWE()
    {
        meanDemand = CalculationMean(arrayDemand);
        meanPlayer = CalculationMean(arrayPlayer);
        meanDistributor = CalculationMean(arrayDistributor);
        meanManufacturer = CalculationMean(arrayManufacturer);

        varDemand = CalculationVariance(arrayDemand, meanDemand);
        varPlayer = CalculationVariance(arrayPlayer, meanPlayer);
        varDistributor = CalculationVariance(arrayDistributor, meanDistributor);
        varManufacturer = CalculationVariance(arrayManufacturer, meanManufacturer);

        BWEPlayer = varPlayer / (float) varDemand;
        BWEDistributor = varDistributor / (float) varDemand;
        BWEManufacturer = varManufacturer / (float) varDemand;

        if (scoreBoard.stageNumber == 1)
        {
            BWEPlayer = 0;
            BWEDistributor = 0;
            BWEManufacturer = 0;
            BWETotal1 = 0;
            BWEPlayer1 = 0;
            BWPlayer1Text.text = "- Day 1: " + BWEPlayer1.ToString($"F{3}");
        }

        if (scoreBoard.stageNumber == 2 && scoreBoard.inputUser == true)
        {
            BWETotal2 = (BWEPlayer + BWEDistributor + BWEManufacturer) / 3;
            BWEPlayer2 = BWEPlayer;
            if(float.IsNaN(BWEPlayer2)) {BWEPlayer2 = 0;}
            BWPlayer2Text.text = "- Day 2: " + BWEPlayer2.ToString($"F{3}");;
        }

        if (scoreBoard.stageNumber == 3)
        {
            BWETotal3 = (BWEPlayer + BWEDistributor + BWEManufacturer) / 3;
            BWEPlayer3 = BWEPlayer;
            if(float.IsNaN(BWEPlayer3)) {BWEPlayer3 = 0;}
            BWPlayer3Text.text = "- Day 3: " + BWEPlayer3.ToString($"F{3}");;
        }

        if (scoreBoard.stageNumber == 4)
        {
            BWETotal4 = (BWEPlayer + BWEDistributor + BWEManufacturer) / 3;
            BWEPlayer4 = BWEPlayer;
            if(float.IsNaN(BWEPlayer4)) {BWEPlayer4 = 0;}
            BWPlayer4Text.text = "- Day 4: " + BWEPlayer4.ToString($"F{3}");;
        }

        if (scoreBoard.stageNumber == 5)
        {
            BWETotal5 = (BWEPlayer + BWEDistributor + BWEManufacturer) / 3;
            BWEPlayer5 = BWEPlayer;
            if(float.IsNaN(BWEPlayer5)) {BWEPlayer5 = 0;}
            BWPlayer5Text.text = "- Day 5: " + BWEPlayer5.ToString($"F{3}");;
        }

        if (scoreBoard.stageNumber == 6)
        {
            BWETotal6 = (BWEPlayer + BWEDistributor + BWEManufacturer) / 3;
            BWEPlayer6 = BWEPlayer;
            if(float.IsNaN(BWEPlayer6)) {BWEPlayer6 = 0;}
            BWPlayer6Text.text = "- Day 6: " + BWEPlayer6.ToString($"F{3}");;
        }

        if (scoreBoard.stageNumber == 7)
        {
            BWETotal7 = (BWEPlayer + BWEDistributor + BWEManufacturer) / 3;
            BWEPlayer7 = BWEPlayer;
            if(float.IsNaN(BWEPlayer7)) {BWEPlayer7 = 0;}
            BWPlayer7Text.text = "- Day 7: " + BWEPlayer7.ToString($"F{3}");;
            BWETotal = (BWETotal1 + BWETotal2 + BWETotal3 + BWETotal4 + BWETotal5 + BWETotal6 + BWETotal7) / 7;
            BWIndexText.text = "- " + BWETotal.ToString($"F{3}");

            if (scoreBoard.phase == "Phase 1: no communication ")
            {
            BWHighscoreEUR1.text = scoreBoard.revenue.ToString($"F{0}");
            BWHighscoreBWE1.text = BWETotal.ToString($"F{3}");
            audioPhaseEnd.PlayOneShot(audioClipEnd1);
            }

            if (scoreBoard.phase == "Phase 2: communication")
            {
            BWHighscoreEUR2.text = scoreBoard.revenue.ToString($"F{0}");
            BWHighscoreBWE2.text = BWETotal.ToString($"F{3}");
            foreach(var player in soundArray)
            {
                player.Pause();
            }
            
            audioPhaseEnd.PlayOneShot(audioClipEnd);
            
            }

        } 
        
        

        var tempNum = 0;
        if (scoreBoard.phase == "No communication - Final")
        {
            tempNum = 7;
            OverviewRoundNumber.text = "Overview round 7";
        }
        else
        {
            OverviewRoundNumber.text = "Overview round " + scoreBoard.stageNumber;
        }
        
        
        RevenueText.text = "- € " + scoreBoard.revenue + " Revenue";
        RevenueDifference.text = "- € " + scoreBoard.revenueDifference + " Difference prev. round";
        TotalRevenue.text = "- € " + scoreBoard.totalRevenue1 + " Lost sales";
        
        
        //BWPlayer1Text.text = "Bullwhip effect: " + BWEPlayer;

    }

    private float CalculationMean(int[] arrayType1)
    {
        if (arrayType1.Length == 0 || scoreBoard.stageNumber <= 0 || scoreBoard.stageNumber > arrayType1.Length)
            return 0f;

        float sum = 0;
        for (int i = 0; i < scoreBoard.stageNumber; i++)
        {
            sum += arrayType1[i];
        }

        return sum / scoreBoard.stageNumber;
    }

    private float CalculationVariance(int[] arrayType2, float mean)
    {
        if (arrayType2.Length == 0 || scoreBoard.stageNumber <= 0 || scoreBoard.stageNumber > arrayType2.Length)
            return 0f;

        int count = 0;
        float sumSquaredDifference = 0;

        for (int i = 0; i < scoreBoard.stageNumber; i++)
        {
            float dif = arrayType2[i] - mean;
            sumSquaredDifference += dif * dif;
            count++;
        }

        return count == 0 ? 0f : sumSquaredDifference / count;
    }

    public void ResetArrays()
    {
        arrayDemand = new int[arraySize];
        arrayPlayer = new int[arraySize];
        arrayDistributor = new int[arraySize];
        arrayManufacturer = new int[arraySize];

            meanDemand = 0f;
            meanPlayer = 0f;
            meanDistributor = 0f;
            meanManufacturer = 0f;

            varDemand = 0f;
            varPlayer = 0f;
            varDistributor = 0f;
            varManufacturer = 0f;

            BWEPlayer = 0f;
            BWEDistributor = 0f;
            BWEManufacturer = 0f;

            BWETotal1 = 0f;
            BWETotal2 = 0f;
            BWETotal3 = 0f;
            BWETotal4 = 0f;
            BWETotal5 = 0f;
            BWETotal6 = 0f;
            BWETotal7 = 0f;
            BWETotal = 0f;
            BWIndexText.text = "";
            
            BWEPlayer1 = 0f;
            BWEPlayer2 = 0f;
            BWEPlayer3 = 0f;
            BWEPlayer4 = 0f;
            BWEPlayer5 = 0f;
            BWEPlayer6 = 0f;
            BWEPlayer7 = 0f;

            BWPlayer2Text.text = "- Day 2: ";
            BWPlayer3Text.text = "- Day 3: ";
            BWPlayer4Text.text = "- Day 4: ";
            BWPlayer5Text.text = "- Day 5: ";
            BWPlayer6Text.text = "- Day 6: ";
            BWPlayer7Text.text = "- Day 7: ";
    }
}
