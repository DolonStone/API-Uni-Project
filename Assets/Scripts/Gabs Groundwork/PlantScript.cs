using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    //Attributes
    public bool isGrowing = false;
    PlantBaseState currentState;
    PlantSeedState seedState = new PlantSeedState();
    PlantGrowingState growingState = new PlantGrowingState();
    PlantHarvestState plantHarvestState = new PlantHarvestState();
    PlantDeadState deadState = new PlantDeadState();
    private float WateredPercentage;
    private string PlantName;
    private WaterNeed WaterNeed;
    private SunlightNeed SunlightNeed;
    private string Cycle;
    private float GrowthRate;
    private DataPerenualResponse plantData;

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        GrowthRate = 2f;
        currentState = seedState;
        currentState.EnterState(this);
        //WaterNeed = (WaterNeed)Enum.Parse(typeof(WaterNeed), "FREQUENT", ignoreCase: true);
        //SunlightNeed = (SunlightNeed)Enum.Parse(typeof(SunlightNeed), "PART_SUN", ignoreCase: true);
        WateredPercentage = 50;

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
            timer = 0;
        }


    }

    public float GetGrowthRate()
    { return GrowthRate; }

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
        Cycle = data.cycle;
        WaterNeed = (WaterNeed)Enum.Parse(typeof(WaterNeed), data.watering, ignoreCase: true);
        SunlightNeed = (SunlightNeed)Enum.Parse(typeof(SunlightNeed), String.Join("_", data.sunlight[0].Split(default(string[]), StringSplitOptions.RemoveEmptyEntries)), ignoreCase: true);
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
