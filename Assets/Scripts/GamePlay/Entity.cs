using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour, IEntity
{
    // Заглушка. TO DO иправить

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
        throw new System.NotImplementedException();
    }
}
