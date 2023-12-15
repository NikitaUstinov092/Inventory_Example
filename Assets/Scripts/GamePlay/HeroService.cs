using UnityEngine;

public class HeroService : MonoBehaviour, IHeroService
{
   [SerializeField]
   private Entity hero;

   public IEntity GetHero()
   {
      return hero;
   }
}

