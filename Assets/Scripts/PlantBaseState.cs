using UnityEngine;

public abstract class PlantBaseState
{
    public abstract void EnterState(PlantScript plant);
    public abstract void UpdateState(PlantScript plant);

}
