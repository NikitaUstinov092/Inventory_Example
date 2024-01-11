using Game.GameEngine.Mechanics;
using UnityEngine;

    public sealed class UEffectHandler_MeleeDamage : UEffectHandler
    {
        [SerializeField] 
        private Player _player;
        
        public override void OnApply(IEffect effect)
        {
            if (effect.TryGetParameter<int>(EffectId.DAMAGE, out var damageMultiplier))
            {
                _player.Damage += damageMultiplier;
            }
        }
        public override void OnDiscard(IEffect effect)
        {
            if (effect.TryGetParameter<float>(EffectId.DAMAGE, out var multiplier))
            {
                _player.Damage -= (int)multiplier;
            }
        }
    }
