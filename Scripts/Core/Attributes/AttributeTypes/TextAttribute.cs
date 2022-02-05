namespace HyperCasual_Engine.Attributes.AttributeTypes
{
    [System.Serializable]
    public class TextAttribute : AttributeBase
    {
        public string value;

        public override object GetValue()
        {
            return value;
        }

        public override void SetValue(object newValue)
        {
            value = (string)newValue;
        }
    }
}