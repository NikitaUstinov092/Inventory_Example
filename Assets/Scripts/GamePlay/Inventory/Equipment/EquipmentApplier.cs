using Zenject;

namespace DefaultNamespace.InventoryAppliers
{
    public class EquipmentApplier: IEquipmentObserver
    {
        private IEntity _hero;

        // public EquipmentApplier(IEntity hero)
        // {
        //     _hero = hero;
        // }

        [Inject]
        private void Construct(IEntity hero)
        {
            _hero = hero;
        }
        void IEquipmentObserver.OnItemAdded(InventoryItem item)
        {
            if (IsEquppable(item))
            {
                var equipmentID = GetEquipmentID(item);
                _hero.Get<IComponent_Equipment>().OpenEquipment(equipmentID);
            }
        }

        void IEquipmentObserver.OnItemRemoved(InventoryItem item)
        {
            if (IsEquppable(item))
            {
                var equipmentID = GetEquipmentID(item);
                _hero.Get<IComponent_Equipment>().CloseEquipment(equipmentID);
            }
        }
        
        private static int GetEquipmentID(InventoryItem item)
        {
            return item.GetComponent<IComponent_GetEquipmentID>().GetEquipmentID();
        }

        private static bool IsEquppable(InventoryItem item)
        {
            return item.Flags.HasFlag(InventoryItemFlags.EQUPPABLE);
        }
    }
}