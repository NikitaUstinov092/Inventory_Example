using Zenject;

public class SceneInstaller : MonoInstaller<SceneInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<EquipmentController>().FromComponentsInHierarchy().AsSingle();
        Container.Bind<InventoryContext>().FromComponentsInHierarchy().AsSingle();
        
        Container.BindInterfacesTo<HeroService>().FromComponentsInHierarchy().AsSingle();
        
        Container.Bind<ItemApplier>().FromComponentsInHierarchy().AsSingle();
        Container.Bind<InventoryObserversContainer>().AsSingle();
        Container.BindInterfacesTo<InventoryAdapter>().AsSingle();
    }
}