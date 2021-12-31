using System;
using System.Collections.Generic;

namespace HyperCasual_Engine.Attributes
{
    [Serializable]
    public class AttributeCollection
    {
        public List<Attribute> attributes;

        public AttributeCollection(List<Attribute> attributes)
        {
            this.attributes = attributes;
        }

        public void AddAttribute<T>() where T : Attribute
        {
            T instance = (T)Activator.CreateInstance(typeof(T));
            attributes.Add(instance);
        }
    }
}