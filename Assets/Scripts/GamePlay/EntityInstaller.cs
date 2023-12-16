using System.Collections.Generic;
using UnityEngine;

public class EntityInstaller : MonoBehaviour
{
   [SerializeField] private List<MonoBehaviour> _monoBehavioursComp;

   private void Awake()
   {
      var entity = GetComponent<Entity>();
      
      foreach (var comp in _monoBehavioursComp)
      {
         entity.AddComponent(comp);
      }
   }
}
