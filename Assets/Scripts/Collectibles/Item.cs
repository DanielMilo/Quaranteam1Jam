using UnityEngine;
using UnityEngine.UI;

public enum EItemType
{
    ITEM1 = 0,
    ITEM2 = 1,
    ITEM3 = 2
}

[CreateAssetMenu(fileName = "Collectible", menuName ="Level Authoring/Collectible")]
public class Item : ScriptableObject
{
    [SerializeField]
    private EItemType m_item;

    [SerializeField]
    private Texture m_texture;

    public EItemType ItemType
    {
        get
        {
            return m_item;
        }
    }

    public Texture Texture
    {
        get
        {
            return m_texture;
        }
    }
}
