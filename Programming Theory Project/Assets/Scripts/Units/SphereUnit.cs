using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereUnit : Unit
{
    private ResourcePile m_CurrentPile = null;
    public float productivityMultiplier = 2;

    protected override void BuildingInRange()
    {
        if (m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.productionSpeed *= productivityMultiplier;
            }
        }
    }

    void ResetProductivity()
    {
        if (m_CurrentPile != null)
        {
            m_CurrentPile.productionSpeed /= productivityMultiplier;
            m_CurrentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }

    public override string GetName()
    {
        return "Sphere";
    }

    public override string GetData()
    {
        return $"Multiplies production speed by {productivityMultiplier} second(s)";
    }
}

