using System;
    public interface IEffector<T>
    {
        event Action<T> OnApplied;

        event Action<T> OnDiscarded;

        void Apply(T effect);

        void Discard(T effect);

        bool IsExists(T effect);

        T[] GetEffects();
    }
