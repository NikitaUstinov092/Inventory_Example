using System.Collections.Generic;

    public class AppliedItemsStorage
    {
        private List<InventoryItem> _appliedItems = new();

        public void AddItem(InventoryItem item)
        {
            if(!_appliedItems.Contains(item))
                _appliedItems.Add(item);
        }
        
        public void RemoveItem(InventoryItem item)
        {
            if (_appliedItems.Contains(item))
                _appliedItems.Remove(item);
        }

        public bool TryGetItem(string name, out InventoryItem item)
        {
            for (int i = 0, count = _appliedItems.Count; i < count; i++)
            {
                var appliedItem = _appliedItems[i];
                if (appliedItem.Name != name) 
                    continue;
            
                item = appliedItem;
                return true;
            }
            item = default;
            return false;
        }
    }
