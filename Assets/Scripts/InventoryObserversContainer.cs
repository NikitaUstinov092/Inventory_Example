using System.Collections.Generic;

public class InventoryObserversContainer 
{
    private readonly List<IInventoryObserver> observers = new();
   
    public void AddObserver(IInventoryObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IInventoryObserver observer)
    {
        observers.Remove(observer);            
    }
    
    public void OnItemAdded(InventoryItem item)
    {
        foreach (var observer in observers)
        {
            observer.OnItemAdded(item);
        }
    }
        
    public void OnItemRemoved(InventoryItem item)
    {
        foreach (var observer in observers)
        {
            observer.OnItemRemoved(item);
        }
    }
}
