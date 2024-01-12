using System.Collections;
using DefaultNamespace.InventoryAppliers;
using GamePlay.Inventory.InventoryTest.Game.Tests;
using NUnit.Framework;
using UnityEngine.TestTools;
using Zenject;

public class InventoryPlayModeTest: ZenjectIntegrationTestFixture
{
    private Player _player;
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
        _player = Container.Resolve<Player>();
    }
    
    [UnityTest]
    public IEnumerator AddItemHeadAndApply()
    {
        var itemID = 0;
        var speedValue = 10;
        
        AddItemAndApply("Hat", itemID, EffectId.MOVE_SPEED, speedValue);
        yield return null;
        
        //Проверка
        Assert.True(_equipmentController.EquipmentIsActive(itemID));
        Assert.True(_player.Speed == speedValue);
    }
    
    [UnityTest]
    public IEnumerator AddItemSwordAndApply()
    {
        var itemID = 1;
        var damageValue = 10;
        
        AddItemAndApply("Sword", itemID, EffectId.DAMAGE, damageValue);
        yield return null;
        
        //Проверка
        Assert.False(_equipmentController.EquipmentIsActive(0));
        Assert.True(_equipmentController.EquipmentIsActive(itemID));
        Assert.True(_player.Damage == damageValue);
    }
    
    [UnityTest]
    public IEnumerator ApplyItemWithoutAdding()
    {
        //Предустановка
        PreInstall();
    
        BindDependencies();
        ResolveDependencies();
       
        PostInstall();
        
        //Установка
        var itemName = "Hat";
        yield return null;
        
        //Действие и Проверка
        Assert.Catch(() => _equipper.ApplyItem(itemName));
    }
    
    [UnityTest]
    public IEnumerator RemoveItemWithoutAdding()
    {
        //Предустановка
        PreInstall();
    
        BindDependencies();
        ResolveDependencies();
       
        PostInstall();
        
        //Установка
        var itemName = "Hat";
        yield return null;
        
        //Действие и Проверка
        Assert.Catch(() => _equipper.ReturnItemInventory(itemName));
    }
    
    [UnityTest]
    public IEnumerator AddItemAndRemove()
    {
        var itemName = "Sword";
        var itemID = 1;
        var damageValue = 10;
        
        //Действие и Проверка
        AddItemAndApply(itemName, itemID, EffectId.DAMAGE, damageValue);
        Assert.True(_equipmentController.EquipmentIsActive(itemID));
        Assert.True(_player.Damage == damageValue);
        yield return null;
        
        //Действие и Проверка
        _equipper.ReturnItemInventory(itemName);
        Assert.False(_equipmentController.EquipmentIsActive(itemID));
        Assert.True(_player.Damage == 0);
    }
    private void AddItemAndApply(string name, int id, EffectId effectId, int effectValue)
    {
        //Предустановка
        PreInstall();
        
        BindDependencies();
        ResolveDependencies();
        
        PostInstall();
        
        //Установка
        SetUpInventoryItem(name, id, effectId, effectValue);
        
        //Действие
        _equipper.ApplyItem(name);
    }
    private void SetUpInventoryItem(string itemName, int itemId, EffectId effectId, int effectValue)
    {
        _equipmentControllerInstaller.InstallEquipment(_equipmentController, itemId);
        
        const InventoryItemFlags itemFlags = InventoryItemFlags.EQUPPABLE | InventoryItemFlags.EFFECTIBLE;
        
        var effect = new Effect(new IntEffectParameter(effectId, effectValue));
        var effectComponent = new Component_Effect(effect);
        
        var equipmentComp = new Component_Equipment() as IComponent_SetEquipmentID;
        equipmentComp.SetEquipmentID(itemId);
        
        var config = _inventoryConfigFactory.GetConfig(itemName, itemId, itemFlags,equipmentComp, effectComponent);
        _inventory.SetUp(config);
    }
}
