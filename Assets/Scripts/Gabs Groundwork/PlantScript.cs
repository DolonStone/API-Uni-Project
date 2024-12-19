using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlantScript : MonoBehaviour,IPointerClickHandler
{
    //Attributes
    public bool isGrowing = false;
    private bool planted = false;
    PlantBaseState currentState;
    PlantSeedState seedState = new PlantSeedState();
    PlantGrowingState growingState = new PlantGrowingState();
    PlantHarvestState plantHarvestState = new PlantHarvestState();
    PlantDeadState deadState = new PlantDeadState();
    [SerializeField]
    private float WateredPercentage;
    private string PlantName;
    private WaterNeed WaterNeed;
    private SunlightNeed SunlightNeed;
    private GrowthRate cycle;
    
    private float growthRate;
    private DataPerenualResponse plantData;
    private Slider waterBar;
    private Slider growBar;
    private Slider sunBar;
    private GameObject plantMenu;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        growthRate = 2f;
        currentState = seedState;
        currentState.EnterState(this);
        //WaterNeed = (WaterNeed)Enum.Parse(typeof(WaterNeed), "FREQUENT", ignoreCase: true);
        //SunlightNeed = (SunlightNeed)Enum.Parse(typeof(SunlightNeed), "PART_SUN", ignoreCase: true);
        WateredPercentage = 50;
        Slider[] sliders = GetComponentsInChildren<Slider>(true);
        for(int i = 0; i < sliders.Length; i++)
        {
            if(sliders[i].gameObject.name == "Water")
            {
                waterBar = sliders[i];
            }
            else if(sliders[i].gameObject.name == "Growth")
            {
                growBar = sliders[i];
            }
            else if(sliders[i].gameObject.name == "Sun")
            {
                sunBar = sliders[i];
            }
        }
        plantMenu = GetComponentsInChildren<Transform>(true)[1].gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            WateredPercentage = 100;

        }
        currentState.UpdateState(this);
        

        timer += Time.deltaTime;


        if (timer > 1)
        {
            
                WateredPercentage = (float)(WateredPercentage * (1 - ((float)(int)WaterNeed / 100)));
                UpdateSlider(waterBar, WateredPercentage);
                timer = 0;
        }
           



    }

    public float GetGrowthRate()
    { return growthRate; }

    public PlantBaseState GetCurrentState() { return currentState; }
    public void SetCurrentState(PlantBaseState _newState)
    {
        currentState = _newState;
    }
    public PlantSeedState GetCurrentSeedState() { return seedState; }

    public PlantGrowingState GetGrowingState() { return growingState; }

    public PlantHarvestState GetHarvestState() { return plantHarvestState; }
    public PlantDeadState GetDeadState() { return deadState; }


    public float GetWateredPercentage() { return WateredPercentage; }
    public float GetSunlightNeed() { return (int)SunlightNeed; }

    public void ParseParenialResponse(DataPerenualResponse data)
    {
        plantData = data;
        PlantName = data.common_name;
        WaterNeed = (WaterNeed)Enum.Parse(typeof(WaterNeed), data.watering, ignoreCase: true);
        cycle = (GrowthRate)Enum.Parse(typeof(GrowthRate), data.cycle, ignoreCase: true);
        growthRate = (float)cycle;
        SunlightNeed = (SunlightNeed)Enum.Parse(typeof(SunlightNeed), String.Join("_", data.sunlight[0].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)), ignoreCase: true);
    }
    private void UpdateSlider(Slider slider, float value)
    {
        slider.value = value;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (plantMenu.activeSelf)
        {
            plantMenu.SetActive(false);
        }
        else
        {
            plantMenu.SetActive(true);
        }
    }
}

public enum WaterNeed
{
    NONE,
    MIN,
    AVERAGE,
    FREQUENT
}

public enum SunlightNeed
{
    FULL_SHADE,
    PART_SHADE,
    PART_SUN,
    FULL_SUN
}
public enum GrowthRate
{
    perennial, 
    annual, 
    biennial, 
    biannual
}