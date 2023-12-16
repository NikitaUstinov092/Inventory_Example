using System.Collections.Generic;
using UnityEngine;

public class EntityInstaller : MonoBehaviour
{
   [SerializeField] private List<MonoBehaviour> _monoBehaviours;

   private void Awake()
   {
      var entity = GetComponent<Entity>();
      entity.AddComponent(_monoBehaviours);
   }
}
