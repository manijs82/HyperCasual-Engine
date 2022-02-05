namespace HyperCasual_Engine.Attributes
{
    [System.Serializable]
    public class Attribute<T> : AttributeBase
    {
        public T value;

        public override object GetValue()
        {
            return value;
        }

        public override void SetValue(object newValue)
        {
            value = (T)newValue;
        }
    }
}