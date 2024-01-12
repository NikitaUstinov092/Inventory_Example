using UnityEngine;

namespace Elementary
{
    public abstract class EffectHandler<T> : IEffectHandler<T>
    {
        public abstract void OnApply(T effect);

        public abstract void OnDiscard(T effect);
    }
}