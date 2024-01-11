using Zenject;

public class HeroService : IHeroService
{
   [Inject]
   private PlayerEntity _hero;

   public IEntity GetHero()
   {
      return _hero;
   }
}

