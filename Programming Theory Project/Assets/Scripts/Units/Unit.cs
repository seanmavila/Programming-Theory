using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Base class for all units. Handles movement order given through the UserControl Script.
[RequireComponent(typeof(NavMeshAgent))] // Requires NavMeshAgent to navigate the scene
public abstract class Unit : MonoBehaviour, MainUIHandler.IUIInfoContent
{

    public float speed = 3;

    protected NavMeshAgent m_Agent;
    protected Building m_Target;

    protected void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.speed = speed;
        m_Agent.acceleration = 999;
        m_Agent.angularSpeed = 999;
    }

    private void Update()
    {
        if (m_Target != null)
        {
            float distance = Vector3.Distance(m_Target.transform.position, transform.position);
            if(distance < 2.0f)
            {
                m_Agent.isStopped = true;
                BuildingInRange();
            }
        }
    }

    public virtual void GoTo(Building target)
    {
        m_Target = target;

        if(m_Target != null)
        {
            m_Agent.SetDestination(m_Target.transform.position);
            m_Agent.isStopped = false;
        }
    }

    public virtual void GoTo(Vector3 position)
    {
        m_Target = null;
        m_Agent.SetDestination(position);
        m_Agent.isStopped = false;
    }

    protected abstract void BuildingInRange();

    public virtual string GetName()
    {
        return "";
    }
    
    public virtual string GetData()
    {
        return "";
    }

    public virtual void GetContent(ref List<Building.InventoryEntry> content)
    {

    }
}
