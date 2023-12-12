using UnityEngine;

public class HeroService : MonoBehaviour, IHeroService
{
   [SerializeField]
   private MonoEntity hero;

   public IEntity GetHero()
   {
      return this.hero;
   }
}

