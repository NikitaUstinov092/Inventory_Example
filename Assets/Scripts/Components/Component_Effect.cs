using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
    public sealed class Component_Effect : IComponent_GetEffect
    {
        public IEffect Effect => _effect;

        [SerializeReference]
        private IEffect _effect = default;
    }
