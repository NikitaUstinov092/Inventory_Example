using DefaultNamespace.InventoryAppliers;
using Zenject;

public class SceneInstaller : MonoInstaller<SceneInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<EquipmentController>().FromComponentsInHierarchy().AsSingle();
        Container.Bind<InventoryContext>().FromComponentsInHierarchy().AsSingle();
        Container.Bind<InventoryItemEquipper>().FromComponentsInHierarchy().AsSingle();
        
       
        Container.Bind<InventoryObserversContainer>().AsSingle();
        Container.BindInterfacesTo<InventoryAdapter>().AsSingle();
        
        Container.BindInterfacesAndSelfTo<UComponent_Equipment>().AsSingle();
        Container.BindInterfacesAndSelfTo<UComponenet_Effector>().AsSingle();
        Container.BindInterfacesAndSelfTo<UEffector>().FromComponentsInHierarchy().AsSingle();
        
        
        Container.BindInterfacesAndSelfTo<EquipmentApplier>().AsSingle();
        Container.BindInterfacesAndSelfTo<EquipmentEffectsApplier>().AsSingle();
        
        Container.BindInterfacesAndSelfTo<PlayerEntity>().AsSingle();
        Container.BindInterfacesTo<PlayerEntityInstaller>().AsSingle();
        Container.BindInterfacesTo<HeroService>().AsSingle();
        
        
        
        
    }
}