using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
    public sealed class ListInventory
    {
        [ShowInInspector, ReadOnly]
        private readonly List<InventoryItem> items;
        public ListInventory(params InventoryItem[] items)
        {
            this.items = new List<InventoryItem>(items);
        }
        public void AddItem(InventoryItem item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
            }
        }
        public void RemoveItem(InventoryItem item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
            }
        }
        public void RemoveItem(string name)
        {
            if (FindItem(name, out var item))
            {
                RemoveItem(item);
            }
        }
        public List<InventoryItem> GetItems()
        {
            return items.ToList();
        }
        public bool FindItem(string name, out InventoryItem result)
        {
            foreach (var inventoryItem in items)
            {
                if (inventoryItem.Name == name)
                {
                    result = inventoryItem;
                    return true;
                }
            }
            
            result = null;
            return false;
        }

      
    }
