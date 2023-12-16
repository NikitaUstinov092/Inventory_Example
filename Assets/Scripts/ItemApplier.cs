using System;
using DefaultNamespace;
using Sirenix.OdinInspector;
using UnityEngine;

public class ItemApplier : MonoBehaviour
{
    public event Action<InventoryItem> OnItemApplied;
    public event Action<InventoryItem> OnItemReturned;
    
    [SerializeField] 
    private InventoryContext _inventoryContext;

    private InventoryAppliedItemsStorage _inventoryApplied;
    
    [Button]
    public void ApplyItem(string name)
    {
        var inventory = _inventoryContext.Inventory;
        
        if (inventory.FindItem(name, out var item))
        {
            inventory.RemoveItem(item);
            _inventoryApplied.AddItem(item);
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
        if (!_inventoryApplied.TryGetGetItem(name, out var item))
        {
            throw new Exception($"Предмета с именем {name} нет в списке применённых предметов");
        }
        _inventoryContext.Inventory.AddItem(item);
        _inventoryApplied.RemoveItem(item);
        OnItemReturned?.Invoke(item);
    }
    private void Start()
    {
        _inventoryApplied = new();
        _inventoryContext = GetComponent<InventoryContext>();
    }
}
