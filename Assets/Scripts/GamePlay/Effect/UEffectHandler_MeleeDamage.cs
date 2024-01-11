using Game.GameEngine.Mechanics;
using Zenject;

public class UEffectHandler_MeleeDamage : UEffectHandler
    {
        [Inject] 
        private Player _player; //TO DO переделать на интерфейс
        
        public override void OnApply(IEffect effect)
        {
            if (effect.TryGetParameter<int>(EffectId.DAMAGE, out var damageMultiplier))
            {
                _player.Damage += damageMultiplier;
            }
        }
        public override void OnDiscard(IEffect effect)
        {
            if (effect.TryGetParameter<int>(EffectId.DAMAGE, out var damageMultiplier))
            {
                _player.Damage -= damageMultiplier;
            }
        }
    }
