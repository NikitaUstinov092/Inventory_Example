using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public sealed class InventoryItem
{
    public string Name => _name;
    public InventoryItemFlags Flags => _flags;
    public InventoryItemMetadata Metadata => _metadata;

    [FormerlySerializedAs("name")] [SerializeField]
    private string _name;

    [FormerlySerializedAs("flags")] [SerializeField]
    private InventoryItemFlags _flags;

    [FormerlySerializedAs("metadata")] [SerializeField]
    private InventoryItemMetadata _metadata;

    [SerializeReference]
    private object[] _components;

    public InventoryItem(
        string name,
        InventoryItemFlags flags,
        InventoryItemMetadata metadata,
        params object[] components
    )
    {
        _name = name;
        _flags = flags;
        _metadata = metadata;
        _components = components;
    }

    public T GetComponent<T>()
    {
        foreach (var component in _components)
        {
            if (component is T tComponent)
            {
                return tComponent;
            }
        }

        throw new Exception($"Component of type {typeof(T).Name} is not found!");
    }

    public InventoryItem Clone()
    {
        var count = _components.Length;
        var components = new object[count];

        for (var i = 0; i < count; i++)
        {
            var component = _components[i];
            
            if (component is ICloneable cloneable)
            {
                component = cloneable.Clone();
            }
            components[i] = component;
        }
            
        return new InventoryItem(_name, _flags, _metadata, _components);
    }
}