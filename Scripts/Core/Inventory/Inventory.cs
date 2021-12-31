using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HyperCasual_Engine.Inventory
{
    [System.Serializable]
    public class Inventory
    {
        public ItemDatabase itemDatabase;
        public bool canContainDuplicateValues;
        [Space]
        public List<ItemAmount> items;

        public void AddItem(ItemDefinition definition, int count = 1)
        {
            if (items.Count(i => i.definition.itemName == definition.itemName) > 0 && !canContainDuplicateValues)
            {
                Debug.LogError("Item already exist in the inventory!");
                return;
            }

            ItemAmount itemAmount = new ItemAmount(definition, count);
            items.Add(itemAmount);
        }

        public void RemoveDuplicates()
        {
            items = items.Distinct(new ItemAmountComparer()).ToList();
        }
    }
}