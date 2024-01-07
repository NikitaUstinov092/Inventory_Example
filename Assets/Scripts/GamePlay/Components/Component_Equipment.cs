using System;
using UnityEngine;

[Serializable]
public class Component_Equipment: IComponent_GetEquipmentID, IComponent_SetEquipmentID
{
    [SerializeField]
    private int _equipmentId;
    
    int IComponent_GetEquipmentID.GetEquipmentID()
    {
        return _equipmentId;
    }

    void IComponent_SetEquipmentID.SetEquipmentID(int id)
    {
        _equipmentId = id;
    }
}

public interface IComponent_GetEquipmentID
{
    int GetEquipmentID();
}

public interface IComponent_SetEquipmentID
{
    void SetEquipmentID(int id);
}

public interface IComponent_Equipment
{
    void OpenEquipment(int id);
    
    void CloseEquipment(int id);
}