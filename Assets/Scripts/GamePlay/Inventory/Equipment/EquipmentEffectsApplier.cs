
    using Zenject;

    public sealed class EquipmentEffectsApplier : IEquipmentObserver
    {
        [Inject]
        private readonly IEntity _hero;

        // public EquipmentEffectsApplier(IEntity hero)
        // {
        //     _hero = hero;
        // }

        void IEquipmentObserver.OnItemAdded(InventoryItem item)
        {
            if (IsEffectible(item))
            {
                var effect = GetEffect(item);
                _hero.Get<IComponent_Effector>().Apply(effect);
            }
        }

        void IEquipmentObserver.OnItemRemoved(InventoryItem item)
        {
            if (IsEffectible(item))
            {
                var effect = GetEffect(item);
                _hero.Get<IComponent_Effector>().Discard(effect);
            }
        }

        private static IEffect GetEffect(InventoryItem item)
        {
            return item.GetComponent<IComponent_GetEffect>().Effect;
        }

        private static bool IsEffectible(InventoryItem item)
        {
            return item.Flags.HasFlag(InventoryItemFlags.EFFECTIBLE);
        }
    }
