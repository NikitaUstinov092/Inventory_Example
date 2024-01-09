using Sirenix.OdinInspector;
using UnityEngine;

    public sealed class InventoryContext: MonoBehaviour
    {
        [ShowInInspector]
        public readonly PlayerInventory Inventory = new();
        
        [Button]
        public void AddItem(InventoryItemConfig config)
        {
            var prefab = config.Item;
            var inventoryItem = prefab.Clone();
            Inventory.AddItem(inventoryItem);
        }
        
        [Button]
        public void RemoveItem(InventoryItemConfig config)
        {
            Inventory.RemoveItem(config.Item.Name);
        }

        public void SetUp(params InventoryItemConfig[] configs)
        {
            foreach (var config in configs)
            {
                var prefab = config.Item;
                var inventoryItem = prefab.Clone();
                Inventory.AddItem(inventoryItem);
            }
        }
    }


