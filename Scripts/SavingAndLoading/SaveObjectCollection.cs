using System.Collections.Generic;
using System.Linq;

namespace HyperCasual_Engine
{
    [System.Serializable]
    public class SaveObjectCollection
    {
        public List<SaveObject> saveObjects;
        
        public SaveObjectCollection(List<SaveObject> list)
        {
            saveObjects = list;
        }

        public void Add(SaveObject saveObject)
        {
            saveObjects.Add(saveObject);
        }

        public SaveObject GetObjectWithKey(string key)
        {
            return saveObjects.FirstOrDefault(s => s.key == key);
        }
    }
}