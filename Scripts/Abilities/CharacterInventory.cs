using HyperCasual_Engine.Inventory;
using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class CharacterInventory : Ability
    {
        [Header("Inventory")]
        public Inventory.Inventory inventory;
        
        public override void Init()
        {
            base.Init();
        }
        
        public void AddItemToInventory(string itemName, ItemDatabase database)
        {
            ItemDefinition item = database.TryGetItem(itemName, out bool founded);
            if (founded)
            {
                inventory.AddItem(item);
            }
        }
    }
}