using DefaultNamespace.InventoryAppliers;
using Zenject;

public class SceneInstaller : MonoInstaller<SceneInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<Player>().FromComponentsInHierarchy().AsSingle();
        BindInventory();
        BindEffects();
        BindComponents();
        BindEquipment();
        BindEntity();
        BindHandlers();
    }
    private void BindInventory()
    {
        Container.Bind<InventoryContext>().FromComponentsInHierarchy().AsSingle();
        Container.Bind<InventoryItemEquipper>().FromComponentsInHierarchy().AsSingle();
        Container.Bind<InventoryObserversContainer>().AsSingle();
        Container.BindInterfacesTo<InventoryAdapter>().AsSingle();
    }
    private void BindEffects()
    {
        Container.BindInterfacesAndSelfTo<UEffector>().AsSingle();
        Container.BindInterfacesTo<EffectsAdapter>().AsSingle();
    }
    private void BindComponents()
    {
        Container.BindInterfacesAndSelfTo<UComponent_Equipment>().AsSingle();
        Container.BindInterfacesAndSelfTo<UComponenet_Effector>().AsSingle();
    }
    private void BindEquipment()
    {
        Container.Bind<EquipmentController>().FromComponentsInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<EquipmentApplier>().AsSingle();
        Container.BindInterfacesAndSelfTo<EquipmentEffectsApplier>().AsSingle();
    }
    private void BindEntity()
    {
        Container.BindInterfacesAndSelfTo<PlayerEntity>().AsSingle();
        Container.BindInterfacesTo<PlayerEntityInstaller>().AsSingle();
        Container.BindInterfacesTo<HeroService>().AsSingle();
    }

    private void BindHandlers()
    {
        Container.BindInterfacesAndSelfTo<UEffectHandler_MeleeDamage>().AsSingle();
        Container.BindInterfacesAndSelfTo<UEffectHandler_SpeedUp>().AsSingle();
    }
    
}