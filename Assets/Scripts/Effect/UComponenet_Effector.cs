using System;
using DefaultNamespace.Effect;
using UnityEngine;

public class UComponenet_Effector : MonoBehaviour, IComponent_Effector
{
   [SerializeField] 
   private EffectController _effectController;
    
   event Action<IEffect> IComponent_Effector.OnApplied
   {
        add => _effectController.OnApplied += value;
        remove => _effectController.OnApplied -= value;
   }
   
   event Action<IEffect> IComponent_Effector.OnDiscarded
   {
       add => _effectController.OnDiscarded += value;
       remove => _effectController.OnDiscarded -= value;
   }
   void IComponent_Effector.Apply(IEffect effect)
   {
       _effectController.Apply(effect);
   }
   void IComponent_Effector.Discard(IEffect effect)
   {
       _effectController.Discard(effect);
   }
}
