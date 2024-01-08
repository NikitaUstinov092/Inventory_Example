using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

public class InventoryRun: ZenjectIntegrationTestFixture
{
    // A Test behaves as an ordinary method
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator InventoryRunWithEnumeratorPasses()
    {
        PreInstall();

        Container.Bind<InventoryContext>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<ItemApplier>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<EquipmentController>().FromNewComponentOnNewGameObject().AsSingle(); 
        Container.BindInterfacesAndSelfTo<InventoryAdapter>().AsSingle(); 
        

        PostInstall();

        var _inventory = Container.Resolve<InventoryContext>();
        var _applier = Container.Resolve<ItemApplier>();
        var _equipmentController = Container.Resolve<EquipmentController>();

        var hatGo = new GameObject("Hat");
        var swordGo = new GameObject("Sword");
      
        hatGo.SetActive(false);
        swordGo.SetActive(false);
        
        _equipmentController.SetUp(hatGo, swordGo);
        
        var itemFlags = InventoryItemFlags.EQUPPABLE | InventoryItemFlags.EFFECTIBLE;
        
        var equipmentComp = new Component_Equipment() as IComponent_SetEquipmentID;
        
        equipmentComp.SetEquipmentID(0);
        
        var config =  ScriptableObject.CreateInstance<InventoryItemConfig>();
        config.name = "Hat";
        var item = new InventoryItem("Hat", itemFlags, new InventoryItemMetadata(),equipmentComp);
        config.Item = item;
         
        _inventory.SetUp(config);
        _applier.ApplyItem("Hat");
        
        Assert.True(_equipmentController.EquipmentIsActive(0));
       // Assert.True(_equipmentController.GetCount() == 2);
      
        yield return null;
    }
}
