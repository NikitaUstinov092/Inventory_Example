using Sirenix.OdinInspector;
using UnityEngine;


    public sealed class InventoryContext : MonoBehaviour, IGetInventory<ListInventory>
    {
        [ShowInInspector]
        public readonly ListInventory Inventory = new();
        
        [Button]
        public void AddItem(InventoryItemConfig config)
        {
            var prefab = config.item;
            var inventoryItem = prefab.Clone();
            Inventory.AddItem(inventoryItem);
        }

        [Button]
        public void RemoveItem(InventoryItemConfig config)
        {
            Inventory.RemoveItem(config.item.Name);
        }

        public ListInventory GetInventory()
        {
            return Inventory;
        }
    }

public interface IGetInventory <T>
{
  T GetInventory();
}
