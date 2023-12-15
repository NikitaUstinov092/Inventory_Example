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
            throw new System.NotImplementedException();
        }

        void IInventoryObserver.OnItemRemoved(InventoryItem item)
        {
            throw new System.NotImplementedException();
        }
    }
}