using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDeadState : PlantBaseState
{
    public override void EnterState(PlantScript plant)
    {
        Debug.Log("Wuh-oh I'm dead :(");
    }
    public override void UpdateState(PlantScript plant)
    {

    }
}
