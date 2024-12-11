using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHarvestState : PlantBaseState
{
    public override void EnterState(PlantScript plant)
    {
        Debug.Log("#PickMe");
    }
    public override void UpdateState(PlantScript plant)
    {

    }
}

