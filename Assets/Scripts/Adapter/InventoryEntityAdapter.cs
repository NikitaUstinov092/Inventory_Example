using UnityEngine;

public class InventoryEntityAdapter : MonoBehaviour
{
    private InventoryContext _inventory;
    private HeroService _heroService;

    private void Awake()
    {
        var hero = _heroService.GetService<IHeroService>().GetHero();
        _inventory.Inventory.AddObserver(new InventoryEffectsApplier(hero));
    }
}
