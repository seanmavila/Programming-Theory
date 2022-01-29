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
    public float jumpForce = 10;

    protected NavMeshAgent m_Agent;

    protected void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.speed = speed;
        m_Agent.acceleration = 999;
        m_Agent.angularSpeed = 999;
    }

    public virtual void GoTo(Vector3 position)
    {
        m_Agent.SetDestination(position);
        m_Agent.isStopped = false;
    }

    public virtual string GetName()
    {
        return "";
    }
    
    public virtual string GetData()
    {
        return "";
    }
}
