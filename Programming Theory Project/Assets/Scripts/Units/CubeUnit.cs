using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeUnit : Unit
{
    protected override void BuildingInRange()
    {
        throw new System.NotImplementedException();
    }
    public override void GoTo(Vector3 position)
    {
        base.GoTo(position);
    }

    public override string GetName()
    {
        return "Cube";
    }

    public override string GetData()
    {
        return "Does cube things";
    }
}


