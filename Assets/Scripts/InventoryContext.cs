using Sirenix.OdinInspector;
using UnityEngine;


    public sealed class InventoryContext : MonoBehaviour
    {
        [ShowInInspector]
        private readonly ListInventory inventory = new();

        [Button]
        public void AddItem(InventoryItemConfig config)
        {
            var prefab = config.item;
            var inventoryItem = prefab.Clone();
            inventory.AddItem(inventoryItem);
        }

        [Button]
        public void RemoveItem(InventoryItemConfig config)
        {
            inventory.RemoveItem(config.item.Name);
        }
    }
