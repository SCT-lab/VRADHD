
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public enum StageGame
{
    Sdefault,
    SP1,
    SP2,
    SP3,
    Stage1,
    Stage2,
    Stage3,
    Stage4,
    Stage5,
    Stage6N,
    Stage7N,
    Stage7Final,
    Stage8,
    Stage9,
    Stage10,
    Stage11,
    Stage12,
    Stage13,
    Stage14,
    Stage14Final
}

public class Scoreboard : UdonSharpBehaviour
{

    public float averageDemandPlayer;
    public float averageDemandDistributor;
    public float averageDemandManufacturer;
    public float safetyStockDistributor;
    public float safetyStockManufacturer;
    //UI elements
    public TextMeshProUGUI PhaseText;
    public TextMeshProUGUI StageNumberText;
    public TextMeshProUGUI RevenueText;
    public TextMeshProUGUI PreviousOrderDemandText;
    public TextMeshProUGUI WasteText;
    public TextMeshProUGUI CostInventoryText;
    public TextMeshProUGUI InventoryText;

    //OrderActors
    public TextMeshProUGUI TransitManufacturer;
    public TextMeshProUGUI TransitMegan;
    public TextMeshProUGUI TransitPlayer;
    
    //OrderActors
    //public TextMeshProUGUI JoshOrderText;
    public TextMeshProUGUI MeganOrderText;
    public TextMeshProUGUI PlayerOrderText;
    public TextMeshProUGUI MarthaOrderText;
    public TextMeshProUGUI JoeOrderText;

    //Inventory values actors
    public TextMeshProUGUI InventoryJoshText;
    public TextMeshProUGUI InventoryMeganText;
    public TextMeshProUGUI InventoryMarthaText;

    public TextMeshPro TimerText;    

    //BarImages
    //public RectTransform JoshBar;
    public RectTransform MeganBar;
    public RectTransform PlayerBar;
    public RectTransform MarthaBar;
    public RectTransform JoeBar;

    //DotImages
    //public RectTransform JoshDot;
    public RectTransform MeganDot;
    public RectTransform PlayerDot;
    public RectTransform MarthaDot;
    public RectTransform JoeDot;

    //Check if the user has put in an order amount
    public bool inputUser = false;
    public bool updateTransit = true;
    public bool PREnabled = false;

    //Absolute UI numbers
    public string phase = "Phase 1: no communication";
    public int stageNumber = 1;
    public int revenue = 0;
    public int revenueDifference = 0;
    public int totalRevenue1 = 0;
    private int previousDemand = 0;
    private int waste = 0;
    public int inventory = 0;
    private int oldInventory = 0;
    private int costInventory = 0;

     //Absolute order numbers
    private int TransitManufacturerValue = 0;
    private int TransitMeganValue = 0;
    private int TransitPlayerValue = 0;
    
    //Absolute order numbers
    //private int JoshOrder = 0;
    public int MeganOrder = 0;
    public int PlayerOrder = 0;
    public int MarthaOrder = 0;
    public int JoeOrder = 0;

    //Absolute inventory numbers
    public int InvJosh = 1000;
    public int InvMegan = 1000;
    public int InvMartha = 1000;

    public bool OrderMeganEnable = false;
    public bool OrderMarthaEnable = false;

    public bool TransitManufacturerEnable = false;
    public bool TransitMeganEnable = false;
    
    public bool InvJoshOn = false;
    public bool InvMeganOn = false;
    public bool InvMarthaOn = false;

    public int maxOrderAmount = 50;
    public int inventoryTemp = 0;

    bool reportActive = false;

    float timer = 8f;

    public GameObject AfterRoundReport;

    public GameObject scoreBoardItem;
    
    public GameObject nextStageMenu;

    public GameObject generalMenu;

    public GameObject[] endScreen;

    public GameObject[] arrayGOend;

    public BullwhipIndex itemBWE;

    public LineRenderer line;

    public StageGame currentStage = StageGame.Sdefault;

    void Start()
    {
        line.positionCount = 4;
        UpdateScoreboard();
    }

    public void UpdateScoreboard()
    {

        switch (currentStage)
        {
            case StageGame.Sdefault:
                itemBWE.ResetArrays();
                inputUser = false;
                phase = "Default";
                stageNumber = 0;
                revenue = 100;
                previousDemand = 0;
                waste = 0;
                inventory = 0;
                oldInventory = 0;
                costInventory = 0;

                averageDemandPlayer = 0;
                averageDemandDistributor = 0;
                averageDemandManufacturer = 0;
                safetyStockDistributor = 0;
                safetyStockManufacturer = 0;

                //Absolute order numbers
                TransitManufacturerValue = 0;
                TransitMeganValue = 0;
                TransitPlayerValue = 0;
                
                //Absolute order numbers
                //private int JoshOrder = 0;
                MeganOrder = 0;
                MarthaOrder = 0;
                JoeOrder = 0;

                OrderMeganEnable = false;
                OrderMarthaEnable = false;

                TransitManufacturerEnable = false;
                TransitMeganEnable = false;

                InvJoshOn = false;
                InvMeganOn = false;
                InvMarthaOn = false;
                
                InvJosh = 9999;
                InvMegan = 15;
                InvMartha = 25;
                break;
            

            case StageGame.Stage1:
                inputUser = false;
                if (updateTransit)
                {
                    InventoryUpdateTransit();
                }
                phase = "Phase 1: no communication";
                totalRevenue1 = 0;
                stageNumber = 1;
                previousDemand = 0;
                waste = 0;
                inventory = 15;
                oldInventory = 0;
                
                //Absolute order numbers
                TransitManufacturerValue = 0;
                TransitMeganValue = 0;
                TransitPlayerValue = 0;
                
                //Absolute order numbers
                //private int JoshOrder = 0;
                SafetyStock();
                MeganOrder = 5;
                MarthaOrder = 5;
                //MeganOrder = 20;
                //MarthaOrder = 15;
                JoeOrder = 5;

                OrderMeganEnable = false;
                OrderMarthaEnable = false;

                TransitManufacturerEnable = false;
                TransitMeganEnable = false;

                InvJoshOn = false;
                InvMeganOn = false;
                InvMarthaOn = false;
 
                break;
            

            case StageGame.Stage2:
                inputUser = false;
                if (updateTransit)
                {
                    InventoryUpdateTransit();
                }
                phase = "Phase 1: no communication";
                stageNumber = 2;
                previousDemand = JoeOrder;
                
                //Absolute order numbers
                TransitManufacturerValue = MeganOrder;
                TransitMeganValue = MarthaOrder;
                TransitPlayerValue = PlayerOrder;
                
                //Absolute order numbers
                SafetyStock();
                PlayerOrder = 0;
                JoeOrder = 8;

                OrderMeganEnable = false;
                OrderMarthaEnable = false;

                TransitManufacturerEnable = false;
                TransitMeganEnable = false;

                InvJoshOn = false;
                InvMeganOn = false;
                InvMarthaOn = false;

                break;

                case StageGame.Stage3:
                inputUser = false;
                if (updateTransit)
                {
                    InventoryUpdateTransit();
                }
                phase = "Phase 1: no communication";
                stageNumber = 3;
                previousDemand = JoeOrder;
                oldInventory = inventory;

                //Absolute order numbers
                TransitManufacturerValue = MeganOrder;
                TransitMeganValue = MarthaOrder;
                TransitPlayerValue = PlayerOrder;
                
                //Absolute order numbers
                //PlayerOrder = 0;
                SafetyStock();
                PlayerOrder = 0;
                //MeganOrder = 20;
                //MarthaOrder = 15;
                JoeOrder = 12;

                OrderMeganEnable = false;
                OrderMarthaEnable = false;

                TransitManufacturerEnable = false;
                TransitMeganEnable = false;

                InvJoshOn = false;
                InvMeganOn = false;
                InvMarthaOn = false;

                break;

                case StageGame.Stage4:
                inputUser = false;
                if (updateTransit)
                {
                    InventoryUpdateTransit();
                }
                phase = "Phase 1: no communication";
                stageNumber = 4;
                previousDemand = JoeOrder;
                oldInventory = 0;

                //Absolute order numbers
                TransitManufacturerValue = MeganOrder;
                TransitMeganValue = MarthaOrder;
                TransitPlayerValue = PlayerOrder;
                
                //Absolute order numbers
                //PlayerOrder = 0;
                SafetyStock();
                PlayerOrder = 0;
                //MeganOrder = 20;
                //MarthaOrder = 15;
                JoeOrder = 8;

                OrderMeganEnable = false;
                OrderMarthaEnable = false;

                TransitManufacturerEnable = false;
                TransitMeganEnable = false;

                InvJoshOn = false;
                InvMeganOn = false;
                InvMarthaOn = false;

                break;

                case StageGame.Stage5:
                inputUser = false;
                if (updateTransit)
                {
                    InventoryUpdateTransit();
                }
                phase = "Phase 1: no communication ";
                stageNumber = 5;
                previousDemand = JoeOrder;
                oldInventory = 0;

                //Absolute order numbers
                TransitManufacturerValue = MeganOrder;
                TransitMeganValue = MarthaOrder;
                TransitPlayerValue = PlayerOrder;
                
                //Absolute order numbers
                //PlayerOrder = 0;
                SafetyStock();
                PlayerOrder = 0;
                //MeganOrder = 20;
                //MarthaOrder = 15;
                JoeOrder = 8;

                OrderMeganEnable = false;
                OrderMarthaEnable = false;

                TransitManufacturerEnable = false;
                TransitMeganEnable = false;

                InvJoshOn = false;
                InvMeganOn = false;
                InvMarthaOn = false;

                break;

                case StageGame.Stage6N:
                inputUser = false;
                if (updateTransit)
                {
                    InventoryUpdateTransit();
                }
                phase = "Phase 1: no communication ";
                stageNumber = 6;
                previousDemand = JoeOrder;
                oldInventory = 0;

                //Absolute order numbers
                TransitManufacturerValue = MeganOrder;
                TransitMeganValue = MarthaOrder;
                TransitPlayerValue = PlayerOrder;
                
                //Absolute order numbers
                //PlayerOrder = 0;
                SafetyStock();
                PlayerOrder = 0;
                //MeganOrder = 20;
                //MarthaOrder = 15;
                JoeOrder = 5;

                OrderMeganEnable = false;
                OrderMarthaEnable = false;

                TransitManufacturerEnable = false;
                TransitMeganEnable = false;

                InvJoshOn = false;
                InvMeganOn = false;
                InvMarthaOn = false;

                break;

                case StageGame.Stage7N:
                inputUser = false;
                if (updateTransit)
                {
                    InventoryUpdateTransit();
                }
                phase = "Phase 1: no communication ";
                stageNumber = 7;
                previousDemand = JoeOrder;
                oldInventory = 0;

                //Absolute order numbers
                TransitManufacturerValue = MeganOrder;
                TransitMeganValue = MarthaOrder;
                TransitPlayerValue = PlayerOrder;
                
                //Absolute order numbers
                //PlayerOrder = 0;
                SafetyStock();
                PlayerOrder = 0;
                //MeganOrder = 20;
                //MarthaOrder = 15;
                JoeOrder = 3;

                OrderMeganEnable = false;
                OrderMarthaEnable = false;

                TransitManufacturerEnable = false;
                TransitMeganEnable = false;

                InvJoshOn = false;
                InvMeganOn = false;
                InvMarthaOn = false;

                break;

                case StageGame.Stage7Final:
                stageNumber = 7;
                phase = "No communication - Final";
                
                OrderMeganEnable = true;
                OrderMarthaEnable = true;

                TransitManufacturerEnable = true;
                TransitMeganEnable = true;

                InvJoshOn = true;
                InvMeganOn = true;
                InvMarthaOn = true;
                break;

                case StageGame.Stage8:     
                inputUser = false;
                if (updateTransit)
                {
                    InventoryUpdateTransit();
                }
                phase = "Phase 2: communication";
                stageNumber = 1;
                revenue = 100;
                totalRevenue1 = 0;
                previousDemand = 0;
                waste = 0;
                inventory = 15;
                oldInventory = 0;

                averageDemandPlayer = 0;
                averageDemandDistributor = 0;
                averageDemandManufacturer = 0;
                safetyStockDistributor = 0;
                safetyStockManufacturer = 0;

                //Absolute order numbers
                TransitManufacturerValue = 0;
                TransitMeganValue = 0;
                TransitPlayerValue = 0;
                
                //Absolute order numbers
                PlayerOrder = 0;
                MeganOrder = 5;
                MarthaOrder = 5;
                JoeOrder = 5;

                OrderMeganEnable = false;
                OrderMarthaEnable = false;

                TransitManufacturerEnable = false;
                TransitMeganEnable = false;

                InvJoshOn = false;
                InvMeganOn = false;
                InvMarthaOn = false;

                InvJosh = 9999;
                InvMegan = 15;
                InvMartha = 25;

                break;

                case StageGame.Stage9:
                inputUser = false;
                if (updateTransit)
                {
                    InventoryUpdateTransit();
                }
                phase = "Phase 2: communication";
                stageNumber = 2;
                previousDemand = JoeOrder;
                oldInventory = inventory;

                //Absolute order numbers
                TransitManufacturerValue = MeganOrder;
                TransitMeganValue = MarthaOrder;
                TransitPlayerValue = PlayerOrder;
                
                //Absolute order numbers
                PlayerOrder = 0;
                SafetyStock();
                //MeganOrder = 20;
                //MarthaOrder = 15;
                JoeOrder = 8;

                OrderMeganEnable = false;
                OrderMarthaEnable = false;

                TransitManufacturerEnable = false;
                TransitMeganEnable = false;

                InvJoshOn = false;
                InvMeganOn = false;
                InvMarthaOn = false;

                break;


                case StageGame.Stage10:
                inputUser = false;
                if (updateTransit)
                {
                    InventoryUpdateTransit();
                }
                phase = "Phase 2: communication";
                stageNumber = 3;
                previousDemand = JoeOrder;
                oldInventory = inventory;

                //Absolute order numbers
                TransitManufacturerValue = MeganOrder;
                TransitMeganValue = MarthaOrder;
                TransitPlayerValue = PlayerOrder;
                
                //Absolute order numbers
                PlayerOrder = 0;
                SafetyStock();
                //MeganOrder = 20;
                //MarthaOrder = 15;
                JoeOrder = 12;

                OrderMeganEnable = false;
                OrderMarthaEnable = false;

                TransitManufacturerEnable = false;
                TransitMeganEnable = false;

                InvJoshOn = false;
                InvMeganOn = false;
                InvMarthaOn = false;

                break;

                case StageGame.Stage11:
                inputUser = false;
                if (updateTransit)
                {
                    InventoryUpdateTransit();
                }
                phase = "Phase 2: communication";
                stageNumber = 4;
                previousDemand = JoeOrder;
                oldInventory = inventory;

                //Absolute order numbers
                TransitManufacturerValue = MeganOrder;
                TransitMeganValue = MarthaOrder;
                TransitPlayerValue = PlayerOrder;
                
                //Absolute order numbers
                PlayerOrder = 0;
                SafetyStock();
                //MeganOrder = 20;
                //MarthaOrder = 15;
                JoeOrder = 8;

                OrderMeganEnable = false;
                OrderMarthaEnable = false;

                TransitManufacturerEnable = false;
                TransitMeganEnable = false;

                InvJoshOn = false;
                InvMeganOn = false;
                InvMarthaOn = false;

                break;

                case StageGame.Stage12:
                inputUser = false;
                if (updateTransit)
                {
                    InventoryUpdateTransit();
                }
                phase = "Phase 2: communication";
                stageNumber = 5;
                previousDemand = JoeOrder;
                oldInventory = inventory;

                //Absolute order numbers
                TransitManufacturerValue = MeganOrder;
                TransitMeganValue = MarthaOrder;
                TransitPlayerValue = PlayerOrder;
                
                //Absolute order numbers
                PlayerOrder = 0;
                SafetyStock();
                //MeganOrder = 20;
                //MarthaOrder = 15;
                JoeOrder = 8;

                OrderMeganEnable = false;
                OrderMarthaEnable = false;

                TransitManufacturerEnable = false;
                TransitMeganEnable = false;

                InvJoshOn = false;
                InvMeganOn = false;
                InvMarthaOn = false;

                break;

                case StageGame.Stage13:
                inputUser = false;
                if (updateTransit)
                {
                    InventoryUpdateTransit();
                }
                phase = "Phase 2: communication";
                stageNumber = 6;
                previousDemand = JoeOrder;
                oldInventory = inventory;

                //Absolute order numbers
                TransitManufacturerValue = MeganOrder;
                TransitMeganValue = MarthaOrder;
                TransitPlayerValue = PlayerOrder;
                
                //Absolute order numbers
                PlayerOrder = 0;
                SafetyStock();
                //MeganOrder = 20;
                //MarthaOrder = 15;
                JoeOrder = 5;

                OrderMeganEnable = false;
                OrderMarthaEnable = false;

                TransitManufacturerEnable = false;
                TransitMeganEnable = false;

                InvJoshOn = false;
                InvMeganOn = false;
                InvMarthaOn = false;

                break;

                case StageGame.Stage14:
                inputUser = false;
                if (updateTransit)
                {
                    InventoryUpdateTransit();
                }
                phase = "Phase 2: communication";
                stageNumber = 7;
                previousDemand = JoeOrder;
                oldInventory = inventory;

                //Absolute order numbers
                TransitManufacturerValue = MeganOrder;
                TransitMeganValue = MarthaOrder;
                TransitPlayerValue = PlayerOrder;
                
                //Absolute order numbers
                PlayerOrder = 0;
                SafetyStock();
                //MeganOrder = 20;
                //MarthaOrder = 15;
                JoeOrder = 3;

                OrderMeganEnable = false;
                OrderMarthaEnable = false;

                TransitManufacturerEnable = false;
                TransitMeganEnable = false;

                InvJoshOn = false;
                InvMeganOn = false;
                InvMarthaOn = false;

                break;
            
                case StageGame.Stage14Final:
                stageNumber = 7;
                phase = "Phase 2: communication";
                break;

                case StageGame.SP1:
                inputUser = false;
                if (updateTransit)
                {
                    InventoryUpdateTransit();
                }
                phase = "Practice";
                stageNumber = 1;
                previousDemand = 0;
                waste = 0;
                inventory = 50;

                //Absolute order numbers
                TransitManufacturerValue = 0;
                TransitMeganValue = 0;
                TransitPlayerValue = 0;
                    
                //Absolute order numbers
                MeganOrder = 0;
                MarthaOrder = 0;
                JoeOrder = 5;

                OrderMeganEnable = true;
                OrderMarthaEnable = true;

                TransitManufacturerEnable = true;
                TransitMeganEnable = true;
                    
                InvJoshOn = true;
                InvMeganOn = true;
                InvMarthaOn = true;

                break;

                case StageGame.SP2:
                inputUser = false;
                if (updateTransit)
                {
                    InventoryUpdateTransit();
                }
                phase = "Practice";
                stageNumber = 2;
                previousDemand = JoeOrder;
                oldInventory = inventory;

                //Absolute order numbers
                TransitManufacturerValue = MeganOrder;
                TransitMeganValue = MarthaOrder;
                TransitPlayerValue = PlayerOrder;
                    
                //Absolute order numbers
                SafetyStock();
                //MeganOrder = 20;
                //MarthaOrder = 15;
                JoeOrder = 5;

                OrderMeganEnable = true;
                OrderMarthaEnable = true;

                TransitManufacturerEnable = true;
                TransitMeganEnable = true;

                InvJoshOn = true;
                InvMeganOn = true;
                InvMarthaOn = true;

                break;

                case StageGame.SP3:
                inputUser = false;
                if (updateTransit)
                {
                    InventoryUpdateTransit();
                }
                phase = "Practice";
                stageNumber = 3;
                previousDemand = JoeOrder;
                oldInventory = inventory;

                //Absolute order numbers
                TransitManufacturerValue = MeganOrder;
                TransitMeganValue = MarthaOrder;
                TransitPlayerValue = PlayerOrder;
                    
                //Absolute order numbers
                SafetyStock();
                //MeganOrder = 20;
                //MarthaOrder = 15;
                JoeOrder = 8;

                OrderMeganEnable = true;
                OrderMarthaEnable = true;

                TransitManufacturerEnable = true;
                TransitMeganEnable = true;

                InvJoshOn = true;
                InvMeganOn = true;
                InvMarthaOn = true;

                break;


            default:
                break;
        }
        
        
    }
    
    public void updateText()
    {
        //Update order values
        //PlayerOrder = ParseInputField(PlayerOrderInput, PlayerOrder);
        //UI text

        PhaseText.text = phase.ToString();
        StageNumberText.text = "Stage: " + stageNumber.ToString() + " / 7";
        RevenueText.text = "Revenue: € " + revenue.ToString();
        InventoryText.text = "Inventory: " + inventory.ToString();
        PreviousOrderDemandText.text = "Prev. order: " + previousDemand.ToString();
        WasteText.text = "Lost sales: " + waste.ToString();

        //Received orders from actors
        if (TransitManufacturerEnable)
        {
            TransitManufacturer.text = "" + TransitManufacturerValue.ToString();
        }
        else
        {
            TransitManufacturer.text = "?";
        }
        
        if (TransitMeganEnable)
        {
            TransitMegan.text = "" + TransitMeganValue.ToString();
        }
        else
        {
             TransitMegan.text = "?";
        }
        
        TransitPlayer.text = "" + TransitPlayerValue.ToString();
        
        //Orders from actors
        //JoshOrderText.text = "" + JoshOrder.ToString();
        //MeganOrderText.text = "" + MeganOrder.ToString();
        PlayerOrderText.text = "" + PlayerOrder.ToString();
        //MarthaOrderText.text = "" + MarthaOrder.ToString();
        JoeOrderText.text = "" + JoeOrder.ToString();

        //Inventory actors
        if (currentStage == StageGame.Sdefault)
        {
            InventoryJoshText.text = "" + InvJosh.ToString();
            InventoryMeganText.text = "" + InvMegan.ToString();
            InventoryMarthaText.text = "" + InvMartha.ToString();
        }
        
        // Order text enabled
        if (OrderMeganEnable)
        {
            MeganOrderText.text = "" + MeganOrder.ToString();
        }
        else
        {
            MeganOrderText.text = "?";
        }

        if (OrderMarthaEnable)
        {
            MarthaOrderText.text = "" + MarthaOrder.ToString();
        }
        else
        {
            MarthaOrderText.text = "?";
        }

        if (InvJoshOn == true)
        {
                InventoryJoshText.text = InvJosh.ToString();
        }
        else
        {
            InventoryJoshText.text = "?";
        }

        if (InvMeganOn == true)
        {
            InventoryMeganText.text = InvMegan.ToString();
        }
        else
        {
            InventoryMeganText.text = "?";
        }

        if (InvMarthaOn == true)
        {
            InventoryMarthaText.text = "" + InvMartha.ToString();
        }     
        else
        {
            InventoryMarthaText.text = "?";
        }

        //BarHeighUpdate
        //UpdateBH(JoshBar, JoshOrder);
        if (currentStage == StageGame.Sdefault)
        {
            UpdateBH(MeganBar, MeganOrder);
            UpdateBH(MarthaBar, MarthaOrder);
            UpdateBH(PlayerBar, PlayerOrder);
            UpdateBH(JoeBar, JoeOrder);

            UpdateDotPosition(MeganDot, MeganOrder, 0);
            UpdateDotPosition(PlayerDot, PlayerOrder, 1);
            UpdateDotPosition(MarthaDot, MarthaOrder, 2);
            UpdateDotPosition(JoeDot, JoeOrder, 3);
        }
        if (OrderMeganEnable)
        {
            UpdateBH(MeganBar, MeganOrder);
        }

        if (OrderMarthaEnable)
        {
            UpdateBH(MarthaBar, MarthaOrder);
        }
        UpdateBH(PlayerBar, PlayerOrder);
        UpdateBH(JoeBar, JoeOrder);


        //UpdateDotPosition(JoshDot, JoshOrder, 0);
        if (OrderMeganEnable)
        {
            UpdateDotPosition(MeganDot, MeganOrder, 0);
        }
        
        if (OrderMarthaEnable)
        {
            UpdateDotPosition(MarthaDot, MarthaOrder, 2);
        }
        UpdateDotPosition(PlayerDot, PlayerOrder, 1);
        UpdateDotPosition(JoeDot, JoeOrder, 3);

        //itemBWE.Start();

        UpdateLineRenderer();
    }

    public void NextStage()
    {
        if (inputUser)
        {
            itemBWE.Start();
            switch(currentStage)
            {
                case StageGame.Sdefault:
                    if (PREnabled)
                    {
                        currentStage = StageGame.SP1;
                        updateTransit = true;
                        break;
                    }
                    else
                    {
                        currentStage = StageGame.Stage1;
                        updateTransit = true;
                        break;
                    }
                    

                case StageGame.Stage1:
                    updateTransit = true;
                    currentStage = StageGame.Stage2;
                    
                    break;
                    
                case StageGame.Stage2:
                    updateTransit = true;
                    currentStage = StageGame.Stage3;
                    updateText();
                    
                    break;
                
                case StageGame.Stage3:
                    updateTransit = true;
                    currentStage = StageGame.Stage4;
                    updateText();
                    
                    break;
                
                case StageGame.Stage4:
                    updateTransit = true;
                    currentStage = StageGame.Stage5;
                    updateText();
                    
                    break;

                case StageGame.Stage5:
                    updateTransit = true;
                    currentStage = StageGame.Stage6N;
                    updateText();
                    
                    break;

                case StageGame.Stage6N:
                    updateTransit = true;
                    currentStage = StageGame.Stage7N;
                    updateText();
                    
                    break;

                case StageGame.Stage7N:
                    updateTransit = true;
                    currentStage = StageGame.Stage7Final;
                    updateText();
                    
                    break;

                case StageGame.Stage7Final:
                    updateTransit = true;
                    currentStage = StageGame.Stage8;
                    updateText();
                    break;

                case StageGame.Stage8:
                    updateTransit = true;
                    currentStage = StageGame.Stage9;
                    updateText();
                    break;

                case StageGame.Stage9:
                    updateTransit = true;
                    currentStage = StageGame.Stage10;
                    updateText();
                    break;

                case StageGame.Stage10:
                    updateTransit = true;
                    currentStage = StageGame.Stage11;
                    updateText();
                    break; 

                case StageGame.Stage11:
                    updateTransit = true;
                    currentStage = StageGame.Stage12;
                    updateText();
                    break;

                case StageGame.Stage12:
                    updateTransit = true;
                    currentStage = StageGame.Stage13;
                    updateText();
                    break;

                case StageGame.Stage13:
                    updateTransit = true;
                    currentStage = StageGame.Stage14;
                    updateText();
                    break;

                case StageGame.Stage14:
                    updateTransit = true;
                    currentStage = StageGame.Stage14Final;
                    updateText();
                    break;                     

                //Practice round
                case StageGame.SP1:
                    currentStage = StageGame.SP2;
                    updateTransit = true;
                    break;

                case StageGame.SP2:
                    currentStage = StageGame.SP3;
                    updateTransit = true;
                    updateText();
                    break;

                case StageGame.SP3:
                    currentStage = StageGame.Sdefault;
                    updateTransit = true;
                    PREnabled = false;
                    updateText();
                    break;

                default:
                    break;
            }
            
            if (currentStage != StageGame.Sdefault && currentStage != StageGame.Stage1)
            {
                AfterRoundReport.SetActive(true);
                reportActive = true;
            }
            
            UpdateScoreboard();
            
            /* if (currentStage != StageGame.Sdefault && currentStage != StageGame.Stage1)
            {
                AfterRoundReport.SetActive(true);
                reportActive = true;
            } */
            
            
        }
        else
        {
            
        }
    }

    public void ResetStage()
    {
        currentStage = StageGame.Sdefault;
        UpdateScoreboard();
        itemBWE.ResetArrays();                            
    }

    private void InventoryUpdateTransit()
    {
        //TransitManufacturerValue = 0;
        //TransitMeganValue = 0;
        //TransitPlayerValue = 0;
     
        if (TransitManufacturerValue > 0)
            InvMegan = InvMegan + TransitManufacturerValue;
            TransitManufacturerValue = 0;
        if (TransitMeganValue > 0)
            InvMartha = InvMartha + TransitMeganValue;
            TransitMeganValue = 0;
        if (TransitPlayerValue > 0)
            inventory = inventory + TransitPlayerValue;
            TransitPlayerValue = 0;
        //updateTransit = false;
    }

    public void InventoryUpdate()
    {
        if (inventory > JoeOrder)
        {
            inventory = inventory - JoeOrder;
        }
        else
        {
            inventory = 0;
        }

        if (InvJosh >= MeganOrder)
            InvJosh = InvJosh - MeganOrder;
        else
            InvJosh = 0;

        if (InvMegan >= MarthaOrder)     
            InvMegan = InvMegan - MarthaOrder;
        else
            InvMegan = 0;

        if (InvMartha >= PlayerOrder)
            InvMartha = InvMartha - PlayerOrder;
        else
            
            InvMartha = 0;            
    }

    public void CostInventoryUpdate()
    {
        if (inventory <= JoeOrder)
        {
            costInventory = 0;
            CostInventoryText.text = "Cost Inv.: € " + costInventory;
        }
        else
        {
            costInventory = (inventory - JoeOrder) * 2;
            CostInventoryText.text = "Cost Inv.: € " + costInventory;
        }
    }
    public void RevenueUpdate()
    {
        if (inventory <= JoeOrder)
        {
            var temp1 = revenue; 
            revenue = revenue + (inventory * 10) - (PlayerOrder * 5) - costInventory;
            revenueDifference = revenue - temp1;
            totalRevenue1 = (waste * 10);
        }

        else
        {
            var temp1 = revenue; 
            revenue = revenue + (JoeOrder * 10) - (PlayerOrder * 5) - costInventory;
            revenueDifference = revenue - temp1;
            totalRevenue1 = (waste * 10);
            
            if (currentStage == StageGame.Stage8)
            {
                totalRevenue1 = 0;
            }
        }
        
    }
    
    public void WasteUpdate()
    {
        if (inventory < JoeOrder)
            waste = waste + (inventory - JoeOrder);
    }

    public void SafetyStock()
    {
        // Safety stock = (average demand * lead time) + safetyStockTemp
        // if safety stock < current stock level --> order
        // itemBWE refers to the BullWhipIndex script that has the arrays
        // safety stock factor indicates to have a 95% service level
        var safetyStockTemp = 1.645;
        var reorderPoint = 25;
        // float averageDemandPlayer = 0;
        // float averageDemandDistributor = 0;
        // float safetyStockDistributor = 0;
        // float safetyStockManufacturer = 0;

        
        if (stageNumber != 0)
        {
            // Distributor controlled by the average demand of the player's input
            averageDemandPlayer = CalculateAverage(itemBWE.arrayPlayer);
            safetyStockDistributor = ((averageDemandPlayer * 1) * (float) safetyStockTemp) + averageDemandPlayer;

            // Manufacturer controlled by the average demand of the distributor
            averageDemandDistributor = CalculateAverage(itemBWE.arrayDistributor);
            safetyStockManufacturer = ((averageDemandDistributor * 1) * (float) safetyStockTemp) + averageDemandDistributor;

            averageDemandManufacturer = CalculateAverage(itemBWE.arrayManufacturer);

            if (Mathf.FloorToInt(safetyStockDistributor) >= InvMartha)
            {
                var tempEOQ = ((averageDemandPlayer * 1) * (float) safetyStockTemp) + Mathf.Sqrt((2 * averageDemandPlayer * 1) / 1);
                if(InvMegan <= tempEOQ)
                {
                    //MarthaOrder = reorderPoint - (reorderPoint - InvMegan);
                    MarthaOrder = (int)tempEOQ - ((int)tempEOQ - InvMegan);
                    updateText();
                }
                else
                {
                    //MarthaOrder = reorderPoint;
                    MarthaOrder = (int)tempEOQ;
                    updateText();
                }
                
            }
            else
            {
                MarthaOrder = 0;
            }

            if (Mathf.FloorToInt(safetyStockManufacturer) >= InvMegan)
            {
                var tempEOQ = ((averageDemandDistributor * 1) * (float) safetyStockTemp) + Mathf.Sqrt((2 * averageDemandPlayer * 1) / 1);
                if(InvJosh <= tempEOQ)
                {
                    MeganOrder = (int)tempEOQ - ((int)tempEOQ - InvJosh);
                    updateText();
                }
                else
                {
                    MeganOrder = (int)tempEOQ;
                    updateText();
                    
                }
                
            }
            else
            {
                MeganOrder = 0;
            }

        }
    }

    float CalculateAverage(int[] array)
    {
        float sum = 0;

        foreach(int num in array)
        {
            sum += num;
        }

        return sum / stageNumber;
    }

    private void UpdateBH(RectTransform bar, int orderAmount)
    {
        float normalizedOrderAmount = (float)orderAmount / (float)maxOrderAmount;
        float maxHeight = 10f;

        // Calculate the height based on the order amount
        float barHeight = orderAmount * maxHeight;

        // Adjust the size delta to increase only the top part of the bar
        bar.sizeDelta = new Vector2(bar.sizeDelta.x, barHeight);
    
        // Adjust the anchored position to move the bottom of the bar accordingly
        bar.anchoredPosition = new Vector2(bar.anchoredPosition.x, barHeight / 2f);
    }

    private void UpdateDotPosition(RectTransform dot, int orderAmount, int index)
    {
        
        float normalizedOrderAmount = (float)orderAmount / (float)maxOrderAmount;
        float maxHeight = 10f;

        float x = dot.anchoredPosition.x;
        float y = orderAmount * maxHeight;

        dot.anchoredPosition = new Vector2(x, y);
        line.SetPosition(index, dot.anchoredPosition);
    }
    
    private void UpdateLineRenderer()
    {
        for (int i = 0; i < line.positionCount; i++)
        {
            line.SetPosition(i, GetDotPosition(i));
        }

        line.startWidth = 0.03f;
        line.endWidth = 0.03f;
    }


    private Vector3 GetDotPosition(int index)
    {
        switch (index)
        {
            //case 0: return JoshDot.anchoredPosition;
            case 0: return MeganDot.anchoredPosition;
            case 1: return MarthaDot.anchoredPosition;
            case 2: return PlayerDot.anchoredPosition;
            case 3: return JoeDot.anchoredPosition;
            default: return Vector3.zero;
        }
    }
    private void Update()
    {
        updateText();
        if (reportActive)
        {
            
            timer -= Time.deltaTime;
            TimerText.text = timer.ToString($"F{1}");

            if (timer < 0f)
            {
                AfterRoundReport.SetActive(false);
                reportActive = false;
                timer = 8f;
                if (!AfterRoundReport.activeSelf && currentStage == StageGame.Stage7Final)
                {
                    scoreBoardItem.SetActive(true);
                    nextStageMenu.SetActive(true);
                    generalMenu.SetActive(false);
                }
                if (!AfterRoundReport.activeSelf && currentStage == StageGame.Stage14Final)
                {
                    scoreBoardItem.SetActive(false);
                    generalMenu.SetActive(false);
                    
                    foreach(var item in endScreen)
                    {
                        item.SetActive(true);
                    }

                    foreach(var item in arrayGOend)
                    {
                        item.SetActive(false);
                    }
                }
            }
        }
    }
}
