using UnityEngine;

namespace Elementary
{
    public abstract class MonoEffectHandler<T> : IEffectHandler<T>
    {
        public abstract void OnApply(T effect);

        public abstract void OnDiscard(T effect);
    }
}