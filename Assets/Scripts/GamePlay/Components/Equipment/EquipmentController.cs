using UnityEngine;

public class EquipmentController: MonoBehaviour
{
    [SerializeField] 
    private GameObject[] _equipment;

    public void SetUp(params GameObject[] equipment)
    {
        _equipment = equipment;
    }
    public void ActivateEquipment(int id)
    {
        _equipment[id].SetActive(true);
    }
    
    public void DeActivateEquipment(int id)
    {
        _equipment[id].SetActive(false);
    }
    
    public bool EquipmentIsActive(int id)
    {
        return _equipment[id].activeInHierarchy;
    }
    
    public int GetCount()
    {
        return _equipment.Length;
    }
}
