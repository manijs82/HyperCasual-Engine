using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HyperCasual_Engine
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private string levelsPrefix;
        [SerializeField] private LoadSceneMode sceneLoadingMethod;
        
        private SceneLoader _sceneLoader;

        private void Awake()
        {
            SaveLoadManager.InitSaveData();
            _sceneLoader = GetComponent<SceneLoader>();
            if(_sceneLoader == null)
                _sceneLoader = gameObject.AddComponent<SceneLoader>();
        }

        public void LoadLevel(int levelNumber)
        {
            _sceneLoader.LoadSceneAsync(levelsPrefix + levelNumber, sceneLoadingMethod);
        }

        private void OnApplicationQuit()
        {
            SaveLoadManager.UpdateSaveFile();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if(!hasFocus)
                SaveLoadManager.UpdateSaveFile();
        }
    }
}