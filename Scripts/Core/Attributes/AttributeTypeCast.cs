using System;

namespace HyperCasual_Engine.Attributes
{
    public static class AttributeTypeCast
    {
        public static AttributeBase GetAttributeFromType(AttributeType attributeType)
        {
            return attributeType switch
            {
                AttributeType.Int => new Attribute<int>(),
                AttributeType.Text => new Attribute<string>(),
                AttributeType.Bool => new Attribute<bool>(),
                _ => throw new ArgumentOutOfRangeException(nameof(attributeType), attributeType, null)
            };
        }
    }
}