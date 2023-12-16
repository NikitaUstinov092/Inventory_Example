using System;
using UnityEngine;

[Serializable]
public class Component_Equipment: IComponent_GetEquipmentID
{
    [SerializeField]
    private int _equipmentId;
    
    int IComponent_GetEquipmentID.GetEquipmentID()
    {
        return _equipmentId;
    }
}

public interface IComponent_GetEquipmentID
{
    int GetEquipmentID();
}

public interface IComponent_Equipment
{
    void OpenEquipment(int id);
    
    void CloseEquipment(int id);
}