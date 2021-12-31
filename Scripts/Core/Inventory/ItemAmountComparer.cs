using System.Collections.Generic;

namespace HyperCasual_Engine.Inventory
{
    public class ItemAmountComparer : IEqualityComparer<ItemAmount>
    {
        public bool Equals(ItemAmount x, ItemAmount y)
        {
            return x.definition.itemName == y.definition.itemName;
        }

        public int GetHashCode(ItemAmount obj)
        {
            return obj.definition.itemName.GetHashCode();
        }
    }
}