using DefaultNamespace.InventoryAppliers;
using Zenject;

public class InventoryAdapter: IInitializable, ILateDisposable 
{
    private InventoryItemEquipper _itemEquipper;
    private InventoryObserversContainer _inventoryObserversContainer;
    private DiContainer _diContainer;
    
    [Inject]
    private void Construct(DiContainer diContainer)
    {
        _diContainer = diContainer;
        _itemEquipper = diContainer.Resolve<InventoryItemEquipper>();
        _inventoryObserversContainer = diContainer.Resolve<InventoryObserversContainer>();;
    }
    private void InitInventoryObservers()
    {
        _inventoryObserversContainer.AddObserver(_diContainer.Resolve<EquipmentEffectsApplier>());
        _inventoryObserversContainer.AddObserver(_diContainer.Resolve<EquipmentApplier>());
    }
    
    void IInitializable.Initialize()
    {
        InitInventoryObservers();
        
        _itemEquipper.OnItemApplied += _inventoryObserversContainer.OnItemAdded;
        _itemEquipper.OnItemReturned += _inventoryObserversContainer.OnItemRemoved;
    }

    void ILateDisposable.LateDispose()
    {
        _itemEquipper.OnItemApplied -= _inventoryObserversContainer.OnItemAdded;
        _itemEquipper.OnItemReturned -= _inventoryObserversContainer.OnItemRemoved;
    }
}
