using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePile : Building
{
    public ResourceItem item;

    public float productionSpeed
    {
        get { return m_ProductionSpeed; }
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("You can't set a negative production speed!");
            }
            else
            {
                m_ProductionSpeed = value;
            }
        }
    }

    private float m_ProductionSpeed = 0.5f;
    private float m_CurrentProduction = 0.0f;

    private void Update()
    {
        if (m_CurrentProduction > 1.0f)
        {
            int amountToAdd = Mathf.FloorToInt(m_CurrentProduction);
            int leftOver = AddItem(item.Id, amountToAdd);

            m_CurrentProduction = m_CurrentProduction - amountToAdd + leftOver;
        }

        if(m_CurrentProduction < 1.0f)
        {
            m_CurrentProduction += m_ProductionSpeed * Time.deltaTime;
        }
    }

    public override string GetData()
    {
        return $"Producing potions at the speed of {m_ProductionSpeed}/s";
    }


}
