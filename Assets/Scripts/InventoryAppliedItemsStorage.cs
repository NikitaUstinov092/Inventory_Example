using System.Collections.Generic;

namespace DefaultNamespace
{
    public class InventoryAppliedItemsStorage
    {
        private List<InventoryItem> _appliedItems = new();

        public void AddItem(InventoryItem item)
        {
            _appliedItems.Add(item);
        }
        
        public void RemoveItem(InventoryItem item)
        {
            if (_appliedItems.Contains(item))
                _appliedItems.Remove(item);
        }

        public bool TryGetGetItem(string name, out InventoryItem item)
        {
            for (int i = 0, count = _appliedItems.Count; i < count; i++)
            {
                var itemInventory = _appliedItems[i];
                if (itemInventory.Name != name) 
                    continue;
            
                item = itemInventory;
                return true;
            }
            item = default;
            return false;
        }
        
    }
}