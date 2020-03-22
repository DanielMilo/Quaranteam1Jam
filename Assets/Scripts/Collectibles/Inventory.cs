using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public delegate void InventoryEvent(Item item);

    public InventoryEvent OnItemAdded;
    public InventoryEvent OnItemRemoved;

    private Dictionary<EItemType, int> m_stock = new Dictionary<EItemType, int>();

    public static Inventory Instance { get; private set; } = null;

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

    public int AmountInStock(EItemType itemType)
    {
        int amount = 0;

        if (m_stock.ContainsKey(itemType))
        {
            amount = m_stock[itemType];
        }

        return amount;
    }
}
