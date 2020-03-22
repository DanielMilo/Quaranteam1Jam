using UnityEngine;

/// <summary>
/// Collectibles are In-Scene proxies for items.
/// </summary>

[ExecuteInEditMode]
[RequireComponent(typeof(Collider))]
public class Collectible : MonoBehaviour
{
    private static string PLAYER_TAG = "Player";

    [SerializeField]
    private Item m_associatedItem;

    private void Awake()
    {
        // make sure the collider is set to trigger from the editor, this method is mostly full-proof. 
        // NOTE: you should remove this logic and if you need more than 1 collider on the GameObject.
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        { 
            Inventory.Instance.AddItem(m_associatedItem);
        }
    }
}
