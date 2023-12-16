using UnityEngine;

public class UComponent_Equipment : MonoBehaviour, IComponent_Equipment
{
    [SerializeField]
    private EquipmentController _equipmentController;
   
    public void OpenEquipment(int id)
    {
        _equipmentController.ActivateEquipment(id);
    }

    public void CloseEquipment(int id)
    {
        _equipmentController.DeActivateEquipment(id);
    }
}
