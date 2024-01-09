using System.Collections.Generic;

public class InventoryObserversContainer 
{
    private readonly List<IEquipmentObserver> _observers = new();
   
    public void AddObserver(IEquipmentObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IEquipmentObserver observer)
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
