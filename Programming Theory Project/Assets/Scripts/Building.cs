using System;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, MainUIHandler.IUIInfoContent
{
    [System.Serializable]
    public class InventoryEntry
    {
        public string ResourceId;
        public int Count;
    }

    [Tooltip("-1 is infinte")]
    public int InventorySpace = -1;

    protected List<InventoryEntry> m_Inventory = new List<InventoryEntry>();

    public List<InventoryEntry> Inventory => m_Inventory;

    protected int m_CurrentAmount = 0;

    public int AddItem(string resourceId, int amount)
    {
        int maxInventorySpace = InventorySpace == -1 ? Int32.MaxValue : InventorySpace;

        if (m_CurrentAmount == maxInventorySpace)
            return amount;

        int found = m_Inventory.FindIndex(item => item.ResourceId == resourceId);
        int addedAmount = Mathf.Min(maxInventorySpace - m_CurrentAmount, amount);

        if (found == -1)
        {
            m_Inventory.Add(new InventoryEntry()
            {
                Count = addedAmount,
                ResourceId = resourceId
            });
        }
        else
        {
            m_Inventory[found].Count += addedAmount;
        }

        m_CurrentAmount += addedAmount;
        return amount - addedAmount;
    }

    public int GetItem(string resourceId, int requestAmount)
    {
        int found = m_Inventory.FindIndex(item => item.ResourceId == resourceId);

        if (found != -1)
        {
            int amount = Mathf.Min(requestAmount, m_Inventory[found].Count);
            m_Inventory[found].Count -= amount;

            if(m_Inventory[found].Count == 0)
            {
                m_Inventory.RemoveAt(found);
            }
            m_CurrentAmount -= amount;
            return amount;
        }
        return 0;
    }

    public virtual string GetName()
    {
        return gameObject.name;
    }

    public virtual string GetData()
    {
        return "";
    }

    public void GetContent(ref List<InventoryEntry> content)
    {
        content.AddRange(m_Inventory);
    }
}
