namespace HyperCasual_Engine.Attributes.AttributeTypes
{
    [System.Serializable]
    public class BoolAttribute : AttributeBase
    {
        public bool value;

        public override object GetValue()
        {
            return value;
        }

        public override void SetValue(object newValue)
        {
            value = (bool)newValue;
        }
    }
}