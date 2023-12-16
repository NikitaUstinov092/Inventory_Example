using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EntityInstaller : MonoBehaviour
{
   [FormerlySerializedAs("_monoBehaviours")] [SerializeField] private List<MonoBehaviour> _monoBehavioursComp;

   private void Awake()
   {
      var entity = GetComponent<Entity>();
      
      foreach (var comp in _monoBehavioursComp)
      {
         entity.AddComponent(comp);
      }
   }
}
