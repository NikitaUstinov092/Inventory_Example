using System;
using UnityEngine;

namespace DefaultNamespace.Effect
{
    public class EffectController: MonoBehaviour
    {
        public Action<IEffect> OnApplied { get; set; }
        public Action<IEffect> OnDiscarded { get; set; }

        public void Apply(IEffect effect)
        {
            throw new NotImplementedException();
        }

        public void Discard(IEffect effect)
        {
            throw new NotImplementedException();
        }
    }
}