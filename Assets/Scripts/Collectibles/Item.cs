using UnityEngine;

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
    private Sprite m_sprite;

    public EItemType ItemType
    {
        get
        {
            return m_item;
        }
    }

    public Sprite Sprite
    {
        get
        {
            return m_sprite;
        }
    }
}
