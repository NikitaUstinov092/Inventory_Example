using UnityEngine;

namespace GamePlay.Inventory.InventoryTest.Game.Tests
{
    public class InventoryConfigFactory
    {
        public InventoryItemConfig GetConfig(string itemName, int id, InventoryItemFlags flags, params object[] components)
        {
            foreach (var component in components)
            {
                if (component is IComponent_SetEquipmentID setIdComp)
                {
                    SetEquipmentData(setIdComp, id);
                }
            }

            return CreateScriptableObjectConfig(itemName,flags, components);
        }
        
        private void SetEquipmentData(IComponent_SetEquipmentID setIdComp, int id)
        {
            setIdComp.SetEquipmentID(id);
        }

        private InventoryItemConfig CreateScriptableObjectConfig(string itemName, InventoryItemFlags flags, object[] components)
        {
            var config =  ScriptableObject.CreateInstance<InventoryItemConfig>();
            config.name = itemName;
            var item = new InventoryItem(itemName, flags, new InventoryItemMetadata(), components);
            config.Item = item;
            return config;
        } 
        
    }

    public class EquipmentControllerInstaller
    {
        public void InstallEquipmentController(EquipmentController equipmentController, string itemName, int id)
        {
            var gameObject = new GameObject(itemName);
            gameObject.SetActive(false);
            equipmentController.SetUp(gameObject);
        }
    }
}