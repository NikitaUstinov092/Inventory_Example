using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[Serializable]
    public sealed class Effect : IEffect
    {
        [FormerlySerializedAs("parameters")] [SerializeReference]
        private List<IEffectParameter> _parameters;

        public Effect()
        {
            _parameters = new List<IEffectParameter>();
        }

        public Effect(params IEffectParameter[] parameters)
        {
            _parameters = new List<IEffectParameter>(parameters);
        }

        public T GetParameter<T>(EffectId name)
        {
            for (int i = 0, count = _parameters.Count; i < count; i++)
            {
                var parameter = _parameters[i];
                if (parameter.Name == name && parameter is IEffectParameter<T> tParameter)
                {
                    return tParameter.Value;
                }
            }
            throw new Exception($"Параметр {name} не найден!");
        }

        public bool TryGetParameter<T>(EffectId name, out T value)
        {
            for (int i = 0, count = this._parameters.Count; i < count; i++)
            {
                var parameter = this._parameters[i];
                if (parameter.Name == name && parameter is IEffectParameter<T> tParameter)
                {
                    value = tParameter.Value;
                    return true;
                }
            }
            
            value = default;
            return false;
        }
    }
