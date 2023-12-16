using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(
    fileName = "InventoryItemConfig",
    menuName = "Inventory/New InventoryItemConfig"
)]
public sealed class InventoryItemConfig : ScriptableObject
{
    [FormerlySerializedAs("item")] [SerializeField]
    public InventoryItem Item;
}