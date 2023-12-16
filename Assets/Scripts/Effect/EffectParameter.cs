using System;
using UnityEngine;
using UnityEngine.Serialization;

public interface IEffectParameter
    {
        EffectId Name { get; }
    }

    public interface IEffectParameter<out T> : IEffectParameter
    {
        T Value { get; }
    }

    [Serializable]
    public abstract class AbstractEffectParameter<T> : IEffectParameter<T>
    {
        public EffectId Name
        {
            get { return _name; }
        }

        public T Value
        {
            get { return _value; }
        }

        [FormerlySerializedAs("name")] [SerializeField]
        private EffectId _name;

        [FormerlySerializedAs("value")] [SerializeField]
        private T _value;

        public AbstractEffectParameter()
        {
        }

        public AbstractEffectParameter(EffectId name, T value)
        {
            _name = name;
            _value = value;
        }
    }

    [Serializable]
    public sealed class IntEffectParameter : AbstractEffectParameter<int>
    {
        public IntEffectParameter()
        {
        }

        public IntEffectParameter(EffectId name, int value) : base(name, value)
        {
        }
    }

    [Serializable]
    public sealed class FloatEffectParameter : AbstractEffectParameter<float>
    {
        public FloatEffectParameter()
        {
        }

        public FloatEffectParameter(EffectId name, float value) : base(name, value)
        {
        }
    }

    [Serializable]
    public sealed class StringEffectParameter : AbstractEffectParameter<string>
    {
        public StringEffectParameter()
        {
        }

        public StringEffectParameter(EffectId name, string value) : base(name, value)
        {
        }
    }
