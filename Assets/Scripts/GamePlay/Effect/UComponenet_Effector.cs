using System;
using Zenject;

public class UComponenet_Effector : IComponent_Effector
{
   [Inject] 
   private UEffector _effectController;
   public event Action<IEffect> OnApplied
   {
        add => _effectController.OnApplied += value;
        remove => _effectController.OnApplied -= value;
   }
   public event Action<IEffect> OnDiscarded
   {
       add => _effectController.OnDiscarded += value;
       remove => _effectController.OnDiscarded -= value;
   }
   public void Apply(IEffect effect)
   {
       _effectController.Apply(effect);
   }
   public void Discard(IEffect effect)
   {
       _effectController.Discard(effect);
   }
}
