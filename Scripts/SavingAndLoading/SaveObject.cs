namespace HyperCasual_Engine
{
    [System.Serializable]
    public class SaveObject
    {
        public string key;
        public object Obj;

        public SaveObject(string key, object obj)
        {
            this.key = key;
            this.Obj = obj;
        }
    }
}