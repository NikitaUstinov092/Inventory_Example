using Game.GameEngine.Mechanics;
using Zenject;

public class UEffectHandler_SpeedUp : UEffectHandler
{
    [Inject] 
    private Player _player; //TO DO переделать на интерфейс
    public override void OnApply(IEffect effect)
    {
        if (effect.TryGetParameter<int>(EffectId.MOVE_SPEED, out var speed)) 
        {
            _player.Speed += speed;
        }
    }
    public override void OnDiscard(IEffect effect)
    {
        if (effect.TryGetParameter<int>(EffectId.MOVE_SPEED, out var speed)) 
        {
            _player.Speed -= speed;
        }
    }
}
