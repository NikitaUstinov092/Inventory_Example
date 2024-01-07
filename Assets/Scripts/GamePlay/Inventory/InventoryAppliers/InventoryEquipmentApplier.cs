namespace DefaultNamespace.InventoryAppliers
{
    public class InventoryEquipmentApplier: IInventoryObserver
    {
        private readonly IEntity _hero;

        public InventoryEquipmentApplier(IEntity hero)
        {
            _hero = hero;
        }
        void IInventoryObserver.OnItemAdded(InventoryItem item)
        {
            if (IsEquppable(item))
            {
                var equipmentID = GetEquipmentID(item);
                _hero.Get<IComponent_Equipment>().OpenEquipment(equipmentID);
            }
        }

        void IInventoryObserver.OnItemRemoved(InventoryItem item)
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