using System.Collections;
using DefaultNamespace.InventoryAppliers;
using GamePlay.Inventory.InventoryTest.Game.Tests;
using NUnit.Framework;
using UnityEngine.TestTools;
using Zenject;

public class InventoryPlayModeTest: ZenjectIntegrationTestFixture
{
    private InventoryContext _inventory;
    private InventoryItemEquipper _equipper ;
    private EquipmentController  _equipmentController;
    
    private EquipmentControllerInstaller _equipmentControllerInstaller = new();
    private InventoryConfigFactory _inventoryConfigFactory = new();
    
    private void BindDependencies()
    {
        Container.Bind<Player>().FromNewComponentOnNewGameObject().AsSingle();
        
        Container.Bind<InventoryContext>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<InventoryItemEquipper>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<InventoryObserversContainer>().AsSingle();
        Container.BindInterfacesTo<InventoryAdapter>().AsSingle();
   
        Container.BindInterfacesAndSelfTo<UEffector>().AsSingle();
        Container.BindInterfacesTo<EffectsAdapter>().AsSingle();
    
        Container.BindInterfacesAndSelfTo<UComponent_Equipment>().AsSingle();
        Container.BindInterfacesAndSelfTo<UComponenet_Effector>().AsSingle();
    
        Container.Bind<EquipmentController>().FromNewComponentOnNewGameObject().AsSingle();
        Container.BindInterfacesAndSelfTo<EquipmentApplier>().AsSingle();
        Container.BindInterfacesAndSelfTo<EquipmentEffectsApplier>().AsSingle();
    
        Container.BindInterfacesAndSelfTo<PlayerEntity>().AsSingle();
        Container.BindInterfacesTo<PlayerEntityInstaller>().AsSingle();
        Container.BindInterfacesTo<HeroService>().AsSingle();
   
        Container.BindInterfacesAndSelfTo<UEffectHandler_MeleeDamage>().AsSingle();
        Container.BindInterfacesAndSelfTo<UEffectHandler_SpeedUp>().AsSingle();
    }

    private void ResolveDependencies()
    {
        _inventory = Container.Resolve<InventoryContext>();
        _equipper = Container.Resolve<InventoryItemEquipper>();
        _equipmentController = Container.Resolve<EquipmentController>();
    }
    
    [UnityTest]
    public IEnumerator CreateItemAndApply()
    {
        //Предустановка
        
        PreInstall();

        BindDependencies();
        ResolveDependencies();
       
        PostInstall();
        
        //Установка
        
        var itemName = "Hat";
        var itemId = 0;

        SetUpInventoryItem(itemName, itemId);
        
        //Действие
        
        _equipper.ApplyItem(itemName);
      
        yield return null;
        
        //Проверка
        
        Assert.True(_equipmentController.EquipmentIsActive(itemId));
    }
    
    [UnityTest]
    public IEnumerator ApplyItemWithoutCreating()
    {
        //Предустановка
        
        PreInstall();
    
        BindDependencies();
        ResolveDependencies();
       
        PostInstall();
        
        //Установка
        
        var itemName = "Hat";
       
        //Действие и Проверка
        
        Assert.Catch(()=> _equipper.ApplyItem(itemName));
        yield return null;
    }

    private void SetUpInventoryItem(string itemName, int itemId)
    {
        const InventoryItemFlags itemFlags = InventoryItemFlags.EQUPPABLE | InventoryItemFlags.EFFECTIBLE;
        
        var effect = new Effect(new IntEffectParameter(EffectId.DAMAGE, 10));
        var effectComponent = new Component_Effect(effect);
        
        var equipmentComp = new Component_Equipment() as IComponent_SetEquipmentID;
        
        var config = _inventoryConfigFactory.GetConfig(itemName, itemId, itemFlags,equipmentComp, effectComponent);
        
        _equipmentControllerInstaller.InstallEquipmentController(_equipmentController, itemName, itemId);
        _inventory.SetUp(config);
    }
}
