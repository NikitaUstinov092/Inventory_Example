using Zenject;

public class EffectsAdapter :  IInitializable
{
    private UEffector _effector;
    private DiContainer _container;

    [Inject]
    private void Construct(DiContainer container)
    {
        _effector = container.Resolve<UEffector>();
        _container = container;
    }
    
    void IInitializable.Initialize()
    {
        _effector.AddHandler(_container.Resolve<UEffectHandler_MeleeDamage>());
        _effector.AddHandler(_container.Resolve<UEffectHandler_SpeedUp>());
    }
}
