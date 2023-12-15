using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IEntity
{
    private List<object> _components = new();
    public void AddComponent(params object[] components)
    {
        _components.Add(components);
    }

    T IEntity.Get<T>()
    {
        throw new System.NotImplementedException();
    }

    bool IEntity.TryGet<T>(out T element)
    {
        throw new System.NotImplementedException();
    }

    object[] IEntity.GetAll()
    {
        return _components.ToArray();
    }
}
