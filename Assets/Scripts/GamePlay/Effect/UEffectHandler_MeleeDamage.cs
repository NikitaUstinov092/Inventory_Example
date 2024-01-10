using Game.GameEngine.Mechanics;
using UnityEngine;


[AddComponentMenu("GameEngine/Mechanics/Effects/Effect Handler «Melee Damage»")]
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
            
            if (effect.TryGetParameter<int>(EffectId.MOVE_SPEED, out var speed)) //TO DO убрать в другой класс
            {
                _player.Speed += speed;
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
