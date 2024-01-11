using Game.GameEngine.Mechanics;
using UnityEngine;
public class UEffectHandler_SpeedUp : UEffectHandler
{
    [SerializeField] 
    private Player _player;
    public override void OnApply(IEffect effect)
    {
        if (effect.TryGetParameter<int>(EffectId.MOVE_SPEED, out var speed)) 
        {
            _player.Speed += speed;
        }
    }
    public override void OnDiscard(IEffect effect)
    {
        if (effect.TryGetParameter<int>(EffectId.MOVE_SPEED, out var speed)) //TO DO убрать в другой класс
        {
            _player.Speed -= speed;
        }
    }
}
