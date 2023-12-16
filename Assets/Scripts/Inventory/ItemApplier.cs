using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class ItemApplier : MonoBehaviour
{
    public event Action<InventoryItem> OnItemApplied;
    public event Action<InventoryItem> OnItemReturned;
    
    [SerializeField] 
    private InventoryContext _inventoryContext;

    private AppliedItemsStorage _appliedItemStorage;
    
    [Button]
    public void ApplyItem(string name)
    {
        var inventory = _inventoryContext.Inventory;
        
        if (inventory.FindItem(name, out var item))
        {
            inventory.RemoveItem(item);
            _appliedItemStorage.AddItem(item);
            OnItemApplied?.Invoke(item);
        }
        else
        {
            throw new Exception($"Предмет с именем {name} не найден в инвенторе!");
        }
    }
    
    [Button]
    public void ReturnItemInventory(string name)
    {
        if (!_appliedItemStorage.TryGetItem(name, out var item))
        {
            throw new Exception($"Предмета с именем {name} нет в списке применённых предметов");
        }
        _inventoryContext.Inventory.AddItem(item);
        _appliedItemStorage.RemoveItem(item);
        OnItemReturned?.Invoke(item);
    }
    private void Start()
    {
        _appliedItemStorage = new();
        _inventoryContext = GetComponent<InventoryContext>();
    }
}
