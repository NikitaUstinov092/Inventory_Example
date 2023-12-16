using System;
using UnityEngine;

namespace DefaultNamespace.Effect
{
    public class EffectController: MonoBehaviour
    {
        public Action<IEffect> OnApplied { get; set; }
        public Action<IEffect> OnDiscarded { get; set; }

        [SerializeField]
        private Player _player;

        public void Apply(IEffect effect)
        {
            
        }

        public void Discard(IEffect effect)
        {
           
        }
    }
}