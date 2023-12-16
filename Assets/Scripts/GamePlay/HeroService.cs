using UnityEngine;
using UnityEngine.Serialization;

public class HeroService : MonoBehaviour, IHeroService
{
   [FormerlySerializedAs("hero")] [SerializeField]
   private Entity _hero;

   public IEntity GetHero()
   {
      return _hero;
   }
}

