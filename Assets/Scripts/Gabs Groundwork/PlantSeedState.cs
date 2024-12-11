using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSeedState : PlantBaseState
{

    public override void EnterState(PlantScript plant)
    {
        Debug.Log("Hello I'm a seed!");
    }
    public override void UpdateState(PlantScript plant)
    {
        if (plant.GetWateredPercentage() >= 75)
        {
            plant.SetCurrentState(plant.GetGrowingState());
            plant.GetGrowingState().EnterState(plant);
        }

        if (plant.GetWateredPercentage() <= 25)
        {
            plant.SetCurrentState(plant.GetDeadState());
            plant.GetDeadState().EnterState(plant);
        }

    }
}
