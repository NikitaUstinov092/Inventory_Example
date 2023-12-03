using UnityEngine;

public class HeroService : MonoBehaviour, IEntity
{
   [SerializeField] 
   private Entity _entity;


   T IEntity.Get<T>()
   {
      throw new System.NotImplementedException();
   }

   bool IEntity.TryGet<T>(out T element)
   {
      throw new System.NotImplementedException();
   }

   object[] IEntity.GetAll()
   {
      throw new System.NotImplementedException();
   }
}

