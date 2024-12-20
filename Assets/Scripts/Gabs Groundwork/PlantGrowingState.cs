using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantGrowingState : PlantBaseState
{
    private float timer = 0.0f;
    private float totalGrowthTime;
    private int CurrentSun = 2;
    public override void EnterState(PlantScript plant)
    {
        Debug.Log("Hello I'm growing!");
        totalGrowthTime = plant.GetGrowthRate()*100;
    }
    public override void UpdateState(PlantScript plant)
    {
        CurrentSun = GlobalWeatherInfo.Instance.sun;


        if (plant.GetWateredPercentage() >= 75 && plant.GetSunlightNeed() == CurrentSun)
        {
            timer += Time.deltaTime;
            plant.SetCurrentGrowTime(timer);
            Debug.Log("Yippee I'm growing!");
        }
        if (timer > totalGrowthTime)
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
