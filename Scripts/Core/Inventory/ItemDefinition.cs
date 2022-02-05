using HyperCasual_Engine.Attributes;

namespace HyperCasual_Engine.Inventory
{
    [System.Serializable]
    public class ItemDefinition
    {
        public string itemName;
        public AttributeCollection attributeCollection;

        public AttributeType nextAttributeType;

        public ItemDefinition(string itemName)
        {
            this.itemName = itemName;
        }
    }
}