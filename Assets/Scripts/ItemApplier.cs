using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class ItemApplier : MonoBehaviour
{
    public event Action<InventoryItem> OnItemApplied;
    public event Action<InventoryItem> OnItemReturned;
    
    [SerializeField] 
    private InventoryContext _inventoryContext;

    [Button]
    public void ApplyItem(string name)
    {
        var inventory = _inventoryContext.Inventory;
        
        if (inventory.FindItem(name, out var item))
        {
            inventory.RemoveItem(item);
            OnItemApplied?.Invoke(item);
        }
        else
        {
            throw new Exception($"Предмет с именем {name} не найден!");
        }
    }
    
    [Button]
    public void ReturnItemInventory(InventoryItem item)
    {
        _inventoryContext.Inventory.AddItem(item);
        OnItemReturned?.Invoke(item);
    }
    private void Start()
    {
        _inventoryContext = GetComponent<InventoryContext>();
    }
}
