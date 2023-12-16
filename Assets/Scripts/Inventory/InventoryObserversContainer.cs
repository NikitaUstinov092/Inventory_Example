using System.Collections.Generic;

public class InventoryObserversContainer 
{
    private readonly List<IInventoryObserver> _observers = new();
   
    public void AddObserver(IInventoryObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IInventoryObserver observer)
    {
        _observers.Remove(observer);            
    }
    
    public void OnItemAdded(InventoryItem item)
    {
        foreach (var observer in _observers)
        {
            observer.OnItemAdded(item);
        }
    }
        
    public void OnItemRemoved(InventoryItem item)
    {
        foreach (var observer in _observers)
        {
            observer.OnItemRemoved(item);
        }
    }
}
