using NUnit.Framework;
using UnityEngine;
using Zenject;

[TestFixture]
public class ZenjectInventoryTest : ZenjectUnitTestFixture
{
    // private InventoryContext _inventory; 
    // private ItemApplier _applier;
    // private EquipmentController _equipmentController;
    
    [SetUp]
    public void CommonInstall()
    {
        Container.Bind<InventoryContext>().AsSingle();
        Container.Bind<ItemApplier>().AsSingle();
        Container.Bind<EquipmentController>().AsSingle(); 
    }
    
    [Test]
    public void ApplyHat()
    {
        //Arrange:
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
         
         
         //Act:
         _applier.ApplyItem("Hat");
         
         //Assert:
          Assert.True(_equipmentController.EquipmentIsActive(0));
         // Assert.True(this.testInventory.GetCount("Stone") == 1);
         // Assert.True(this.testInventory.GetCount("Axe") == 1);
    }
}