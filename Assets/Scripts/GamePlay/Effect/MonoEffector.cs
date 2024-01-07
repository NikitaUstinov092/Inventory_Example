using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Elementary
{
    public abstract class MonoEffector<T> : MonoBehaviour, IEffector<T>
    {
        public event Action<T> OnApplied;

        public event Action<T> OnDiscarded;

        [Space]
        [ShowInInspector, ReadOnly]
        private List<T> _effects = new();

        [FormerlySerializedAs("handlers")]
        [Space]
        [SerializeField]
        private List<MonoEffectHandler<T>> _handlers = new();

        [Title("Methods")]
        [Button]
        public void Apply(T effect)
        {
            for (var i = 0; i < _handlers.Count; i++)
            {
                var handler = _handlers[i];
                handler.OnApply(effect);
            }

            _effects.Add(effect);
            OnApplied?.Invoke(effect);
        }

        [Button]
        public void Discard(T effect)
        {
            if (!_effects.Remove(effect))
            {
                return;
            }

            for (var i = 0; i < _handlers.Count; i++)
            {
                var handler = _handlers[i];
                handler.OnDiscard(effect);
            }

            OnDiscarded?.Invoke(effect);
        }

        public bool IsExists(T effect)
        {
            return _effects.Contains(effect);
        }

        public T[] GetEffects()
        {
            return _effects.ToArray();
        }
    }
}