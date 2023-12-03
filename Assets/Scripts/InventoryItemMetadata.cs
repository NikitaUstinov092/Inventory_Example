using System;
using UnityEngine;

[Serializable]
public sealed class InventoryItemMetadata
{
    [SerializeField]
    public string title;

    [TextArea]
    [SerializeField]
    public string description;

    [SerializeField]
    public Sprite icon;
}