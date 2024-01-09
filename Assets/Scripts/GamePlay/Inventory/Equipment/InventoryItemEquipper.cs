using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class InventoryItemEquipper: MonoBehaviour
{
    public event Action<InventoryItem> OnItemApplied;
    public event Action<InventoryItem> OnItemReturned;
    
    [Inject] 
    private InventoryContext _inventoryContext;

    private PlayerEquipment _playerEquipment = new();
    
    [Button]
    public void ApplyItem(string name)
    {
        var inventory = _inventoryContext.Inventory;
        
        if (inventory.FindItem(name, out var item))
        {
            inventory.RemoveItem(item);
            _playerEquipment.AddItem(item);
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
        if (!_playerEquipment.TryGetItem(name, out var item))
        {
            throw new Exception($"Предмета с именем {name} нет в списке применённых предметов");
        }
        _inventoryContext.Inventory.AddItem(item);
        _playerEquipment.RemoveItem(item);
        OnItemReturned?.Invoke(item);
    }
}
