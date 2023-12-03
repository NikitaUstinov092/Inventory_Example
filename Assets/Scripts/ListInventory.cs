using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
    public sealed class ListInventory
    {
        [ShowInInspector, ReadOnly]
        private readonly List<InventoryItem> items;
        private readonly List<IInventoryObserver> observers = new();

        public ListInventory(params InventoryItem[] items)
        {
            this.items = new List<InventoryItem>(items);
        }

        public void AddItem(InventoryItem item)
        {
            if (!this.items.Contains(item))
            {
                this.items.Add(item);
                this.OnItemAdded(item);
            }
        }
        
        public void RemoveItem(InventoryItem item)
        {
            if (this.items.Remove(item))
            {
                this.OnItemRemoved(item);
            }
        }

        public void RemoveItem(string name)
        {
            if (this.FindItem(name, out var item))
            {
                this.RemoveItem(item);
            }
        }

        public List<InventoryItem> GetItems()
        {
            return this.items.ToList();
        }

        public void AddObserver(IInventoryObserver observer)
        {
            this.observers.Add(observer);
        }

        public void RemoveObserver(IInventoryObserver observer)
        {
            this.observers.Remove(observer);            
        }

        public bool FindItem(string name, out InventoryItem result)
        {
            foreach (var inventoryItem in this.items)
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

        private void OnItemAdded(InventoryItem item)
        {
            foreach (var observer in this.observers)
            {
                observer.OnItemAdded(item);
            }
        }
        
        private void OnItemRemoved(InventoryItem item)
        {
            foreach (var observer in this.observers)
            {
                observer.OnItemRemoved(item);
            }
        }
    }