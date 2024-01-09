using Zenject;

public class UComponent_Equipment : IComponent_Equipment
{
    [Inject]
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
