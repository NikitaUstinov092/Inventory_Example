using UnityEngine;
using Zenject;

public class HeroService : IHeroService
{
   [Inject]
   private PlayerEntity _hero;

   public IEntity GetHero()
   {
      return _hero;
   }
   // public void SetEntity(Entity entity)
   // {
   //    _hero = entity;
   // }
}

