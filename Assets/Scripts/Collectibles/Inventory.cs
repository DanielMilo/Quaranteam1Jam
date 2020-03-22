using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    delegate void InventoryEvent(Item item);

    InventoryEvent OnItemAdded;
    InventoryEvent OnItemRemoved;

    private Dictionary<EItemType, int> m_stock;

    public static Inventory Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddItem(Item item)
    {
        if (!m_stock.ContainsKey(item.ItemType))
        {
            m_stock.Add(item.ItemType, 1);
        }
        else
        {
            m_stock[item.ItemType] += 1;
        }

        OnItemAdded?.Invoke(item);
    }

    public void RemoveItem(Item item)
    {
        if (m_stock.ContainsKey(item.ItemType))
        {
            m_stock.Remove(item.ItemType);
        }


        OnItemRemoved?.Invoke(item);
    }
}
