using Sirenix.OdinInspector;
using UnityEngine;

public class ItemApplier : MonoBehaviour
{
    [SerializeField] private InventoryContext _inventoryContext;
    [SerializeField] private InventoryItem _item;

    [Button]
    public void ApplyItem(string name)
    {
        if (_inventoryContext.Inventory.FindItem(name, out _item))
        {
            Debug.Log($"Success + {_item.Name}" );
        }
    }
    private void Start()
    {
        _inventoryContext = GetComponent<InventoryContext>();
    }
}
