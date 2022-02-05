namespace HyperCasual_Engine.Attributes
{
    [System.Serializable]
    public class AttributeBase
    {
        public string attributeName;
        public AttributeType attributeType;

        public virtual object GetValue()
        {
            return default;
        }
        
        public virtual void SetValue(object newValue)
        {
            
        }
    }
}