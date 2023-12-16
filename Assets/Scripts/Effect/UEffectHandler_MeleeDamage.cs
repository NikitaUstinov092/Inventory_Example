using Game.GameEngine.Mechanics;
using UnityEngine;
using UnityEngine.Serialization;


[AddComponentMenu("GameEngine/Mechanics/Effects/Effect Handler «Melee Damage»")]
    public sealed class UEffectHandler_MeleeDamage : UEffectHandler
    {
        [SerializeField]
        private int _damageMultiplier;

        [SerializeField] 
        private Player _player;
        
        public override void OnApply(IEffect effect)
        {
            if (effect.TryGetParameter<float>(EffectId.DAMAGE, out var multiplier))
            {
                _player.damage += (int)multiplier;
            }
        }

        public override void OnDiscard(IEffect effect)
        {
            if (effect.TryGetParameter<float>(EffectId.DAMAGE, out var multiplier))
            {
                _player.damage -= (int)multiplier;
            }
        }
    }
