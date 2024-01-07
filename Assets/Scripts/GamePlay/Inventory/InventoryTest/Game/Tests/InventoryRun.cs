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

        Container.Bind<InventoryContext>().FromComponentsInHierarchy().AsSingle();
        Container.Bind<ItemApplier>().FromComponentsInHierarchy().AsSingle();
        Container.Bind<EquipmentController>().FromComponentsInHierarchy().AsSingle(); 

        PostInstall();

        var _inventory = Container.Resolve<InventoryContext>();
        var _applier = Container.Resolve<ItemApplier>();
      
        var _equipmentController = Container.Resolve<EquipmentController>();
         
        _equipmentController.SetUp(new GameObject("Hat"),new GameObject("Sword"));
        
        var itemFlags = InventoryItemFlags.EQUPPABLE | InventoryItemFlags.EFFECTIBLE;
        var equipmentComp = new Component_Equipment();
       
        if (equipmentComp is IComponent_SetEquipmentID idSetter)
        {
            idSetter.SetEquipmentID(0);
        }
       
        var config =  ScriptableObject.CreateInstance<InventoryItemConfig>();
        config.name = "Hat";
        var item = new InventoryItem("Hat", itemFlags, new InventoryItemMetadata(),equipmentComp);
        config.Item = item;
         
        _inventory.SetUp(config);
        _applier.ApplyItem("Hat");

        yield return null;

        // Should move in the direction of the velocity
        Assert.True(_equipmentController.EquipmentIsActive(0));
    }
}
