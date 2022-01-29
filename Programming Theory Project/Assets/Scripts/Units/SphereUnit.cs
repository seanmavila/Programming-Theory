using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereUnit : Unit
{
    public override void GoTo(Vector3 position)
    {
        base.GoTo(position);
    }

    public override string GetName()
    {
        return "Sphere";
    }

    public override string GetData()
    {
        return "Does sphere things";
    }
}
