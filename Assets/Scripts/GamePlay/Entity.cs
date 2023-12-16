using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Entity : MonoBehaviour, IEntity
{
    [ShowInInspector]
    private readonly List<object> _components = new();
    public void AddComponent(object components)
    {
        _components.Add(components);
    }

    T IEntity.Get<T>()
    {
       
           for (int i = 0, count = _components.Count; i < count; i++)
           {
               var component = _components[i];
               
               if (component is T result)
               {
                   return result;
               }
           }
           throw new Exception($"Компонент {typeof(T).Name} не найден!");
    }

    bool IEntity.TryGet<T>(out T element)
    {
        for (int i = 0, count = _components.Count; i < count; i++)
        {
            var component = _components[i];
            if (component is not T tComponent) 
                continue;
            
            element = tComponent;
            return true;
        }
        element = default;
        return false;
    }

    object[] IEntity.GetAll()
    {
        return _components.ToArray();
    }
}
