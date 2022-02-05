using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HyperCasual_Engine.Inventory
{
    [CreateAssetMenu(fileName = "Items", menuName = "HCE/Item List")]
    public class ItemDatabase : ScriptableObject
    {
        public List<ItemDefinition> itemDefinitions;

        public ItemDefinition TryGetItem(string itemName, out bool founded)
        {
            var item = itemDefinitions.FirstOrDefault(i => i.itemName == itemName);
            if(item == null)
            {
                Debug.LogError("Item does not exist in this database");
                founded = false;
                
                return null;
            }

            founded = true;
            return item;
        }

        public void AddItem(string itemName)
        {
            itemDefinitions.Add(new ItemDefinition(itemName));
        }
        
        public void RemoveItem(ItemDefinition item)
        {
            itemDefinitions.Remove(item);
        }
    }
}