using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    [SerializeField] private GameObject[] _equipment;
    
    public void ActivateEquipment(int id)
    {
        _equipment[id].SetActive(true);
    }
    
    public void DeActivateEquipment(int id)
    {
        _equipment[id].SetActive(false);
    }
}
