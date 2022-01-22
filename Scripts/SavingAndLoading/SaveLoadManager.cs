using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace HyperCasual_Engine
{
    public static class SaveLoadManager
    {
        private static readonly string SaveFolder = Application.persistentDataPath + "/Saves/";
        private static readonly string SavePath = Application.persistentDataPath + "/Saves/SaveData.json";
        private static SaveObjectCollection saveObjects;

        public static void InitSaveData()
        {
            saveObjects = new SaveObjectCollection(new List<SaveObject>());
            if (!Directory.Exists(SaveFolder))
            {
                Directory.CreateDirectory(SaveFolder);
            }
            if (!File.Exists(SavePath))
            {
                TextFileWriter.CreateEmptyFile(SavePath);
                var emptySaveString = JsonConvert.SerializeObject(saveObjects);
                TextFileWriter.OverwriteFile(SavePath, emptySaveString);
                return;
            }

            var savedString = TextFileWriter.GetText(SavePath);
            saveObjects = JsonConvert.DeserializeObject<SaveObjectCollection>(savedString);
        }
        
        public static void Save(object obj, string key)
        {
            saveObjects.Add(new SaveObject(key, obj));
        }
        
        public static T Load<T>(string key, T defaultValue)
        {
            if (saveObjects.GetObjectWithKey(key) == null)
            {
                Save(defaultValue, key);
            }

            object obj = saveObjects.GetObjectWithKey(key).Obj;
            if (obj is T) 
            {
                return (T)obj;
            } 
            return default;
        }

        public static void UpdateSaveFile()
        {
            var newData = JsonConvert.SerializeObject(saveObjects);
            TextFileWriter.OverwriteFile(SavePath, newData);
        }

        public static void ClearAllSaveData()
        {
            saveObjects = new SaveObjectCollection(new List<SaveObject>());
            if (!Directory.Exists(SaveFolder))
            {
                Directory.CreateDirectory(SaveFolder);
            }

            if (!File.Exists(SavePath)) return;
            var emptySaveString = JsonConvert.SerializeObject(saveObjects);
            TextFileWriter.OverwriteFile(SavePath, emptySaveString);
        }
    }
}