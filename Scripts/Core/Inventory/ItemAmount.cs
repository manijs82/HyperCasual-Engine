using UnityEngine;

namespace HyperCasual_Engine.Inventory
{
    [System.Serializable]
    public struct ItemAmount
    {
        [HideInInspector] public ItemDefinition definition;
        public int count;

        public int Count
        {
            get => count;
            set => count = value;
        }

        public ItemAmount(ItemDefinition definition, int count)
        {
            this.definition = definition;
            this.count = count;
        }

        public void ChangeDefinition(ItemDefinition definition)
        {
            this.definition = definition;
        }
    }
}