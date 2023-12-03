using UnityEngine;

[CreateAssetMenu(
    fileName = "InventoryItemConfig",
    menuName = "Inventory/New InventoryItemConfig"
)]
public sealed class InventoryItemConfig : ScriptableObject
{
    [SerializeField]
    public InventoryItem item;
}