
    public interface IEffect
    {
        T GetParameter<T>(EffectId name);

        bool TryGetParameter<T>(EffectId name, out T value);
    }

   