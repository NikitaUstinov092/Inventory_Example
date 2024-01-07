using DefaultNamespace.InventoryAppliers;
using Zenject;

public class InventoryAdapter: IInitializable, ILateDisposable 
{
    private ItemApplier _itemApplier;
    private IHeroService _heroService;
    private InventoryObserversContainer _inventoryObserversContainer;
    
    [Inject]
    private void Construct(ItemApplier itemApplier, IHeroService heroService, InventoryObserversContainer inventoryObserversContainer)
    {
        _itemApplier = itemApplier;
        _heroService = heroService;
        _inventoryObserversContainer = inventoryObserversContainer;
    }
    private void InitInventoryObservers()
    {
        var hero = _heroService.GetHero();
        _inventoryObserversContainer.AddObserver(new InventoryEffectsApplier(hero));
        _inventoryObserversContainer.AddObserver(new InventoryEquipmentApplier(hero));
    }
    
    void IInitializable.Initialize()
    {
        InitInventoryObservers();
        
        _itemApplier.OnItemApplied += _inventoryObserversContainer.OnItemAdded;
        _itemApplier.OnItemReturned += _inventoryObserversContainer.OnItemRemoved;
    }

    void ILateDisposable.LateDispose()
    {
        _itemApplier.OnItemApplied -= _inventoryObserversContainer.OnItemAdded;
        _itemApplier.OnItemReturned -= _inventoryObserversContainer.OnItemRemoved;
    }
}
