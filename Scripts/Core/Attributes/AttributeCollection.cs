using System;
using System.Collections.Generic;
using UnityEngine;

namespace HyperCasual_Engine.Attributes
{
    [Serializable]
    public class AttributeCollection
    {
        [SerializeReference] public List<AttributeBase> attributes;

        public int Count => attributes.Count;

        public AttributeCollection(List<AttributeBase> attributes)
        {
            this.attributes = attributes;
        }
        
        public void AddAttribute(AttributeBase attribute)
        {
            attributes.Add(attribute);
        }
        
        public void RemoveAttribute(AttributeBase attribute)
        {
            if(attributes.Contains(attribute))
                attributes.Remove(attribute);
        }
    }
}