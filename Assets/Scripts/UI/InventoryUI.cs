using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform m_inventoryRoot;

    private Dictionary<EItemType, GameObject> m_itemTypeToTransformMap = new Dictionary<EItemType, GameObject>();

    public void Start()
    {
        Inventory.Instance.OnItemAdded += OnItemAdded;
        Inventory.Instance.OnItemRemoved += OnItemAdded;
    }

    public void OnItemAdded(Item item)
    {
        if (!m_itemTypeToTransformMap.ContainsKey(item.ItemType))
        {
            GameObject itemVisual = new GameObject();
            itemVisual.gameObject.AddComponent<Image>().sprite = item.Sprite;
            itemVisual.transform.SetParent(m_inventoryRoot);

            m_itemTypeToTransformMap.Add(item.ItemType, itemVisual);
        }
    }

    public void OnItemRemoved(Item item)
    {
        if (m_itemTypeToTransformMap.ContainsKey(item.ItemType))
        {
            Destroy(m_itemTypeToTransformMap[item.ItemType]);
            m_itemTypeToTransformMap.Remove(item.ItemType);
        }
    }
}
