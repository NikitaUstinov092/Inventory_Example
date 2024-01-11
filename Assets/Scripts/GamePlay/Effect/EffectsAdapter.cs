using Elementary;
using UnityEngine;
using Zenject;

public class EffectsAdapter : MonoBehaviour, IInitializable
{
    [Inject]
    private UEffector _effector;
   
    [SerializeField]
    private MonoEffectHandler<IEffect>[] _handlers;

    void IInitializable.Initialize()
    {
        foreach (var handler in _handlers)
        {
            _effector.AddHandler(handler);
        }
    }
}
