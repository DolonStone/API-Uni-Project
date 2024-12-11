using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantGrowingState : PlantBaseState
{
    private float timer = 0.0f;
    private float growthTime;
    private int CurrentSun = 2;
    public override void EnterState(PlantScript plant)
    {
        Debug.Log("Hello I'm growing!");
        growthTime = plant.GetGrowthRate();
    }
    public override void UpdateState(PlantScript plant)
    {



        if (plant.GetWateredPercentage() >= 75 && plant.GetSunlightNeed() == CurrentSun)
        {
            timer += Time.deltaTime;
            Debug.Log("Yippee I'm growing!");
        }
        if (timer > growthTime)
        {

            plant.SetCurrentState(plant.GetHarvestState());
            plant.GetCurrentState().EnterState(plant);
        }
        if (plant.GetWateredPercentage() <= 25)
        {
            plant.SetCurrentState(plant.GetDeadState());
            plant.GetDeadState().EnterState(plant);
        }
    }
}
