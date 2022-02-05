namespace HyperCasual_Engine.Attributes.AttributeTypes
{
    [System.Serializable]
    public class IntAttribute : AttributeBase
    {
        public int value;

        public override object GetValue()
        {
            return value;
        }

        public override void SetValue(object newValue)
        {
            value = (int) newValue;
        }
    }
}