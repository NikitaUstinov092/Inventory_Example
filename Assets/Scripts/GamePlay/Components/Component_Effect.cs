using System;
using UnityEngine;

[Serializable]
    public sealed class Component_Effect : IComponent_GetEffect
    {
        public Component_Effect(IEffect effect)
        {
            _effect = effect;
        }
        public IEffect Effect
        {
            get => _effect;
        }
        
        [SerializeReference]
        private IEffect _effect = default;
    }
