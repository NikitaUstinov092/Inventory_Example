using DefaultNamespace.InventoryAppliers;
using UnityEngine;

public class InventoryAdapter : MonoBehaviour
{
    [SerializeField] 
    private ItemApplier _itemApplier;
    
    [SerializeField]
    private HeroService _heroService;
    
    private InventoryObserversContainer _inventoryObserversContainer = new();
    
    private void Awake()
    {
        var hero = _heroService.GetHero();
        _inventoryObserversContainer.AddObserver(new InventoryEffectsApplier(hero));
        _inventoryObserversContainer.AddObserver(new InventoryEquipmentApplier(hero));
    }

    private void OnEnable()
    {
        _itemApplier.OnItemApplied += _inventoryObserversContainer.OnItemAdded;
        _itemApplier.OnItemReturned += _inventoryObserversContainer.OnItemRemoved;
    }

    private void OnDisable()
    {
        _itemApplier.OnItemApplied -= _inventoryObserversContainer.OnItemAdded;
        _itemApplier.OnItemReturned -= _inventoryObserversContainer.OnItemRemoved;
    }
}
