using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace HyperCasual_Engine
{
    public class SceneLoader : MonoBehaviour
    {
        public UnityEvent<AsyncOperation> onLoadSceneStarted;
        public UnityEvent<AsyncOperation> onUnLoadSceneStarted;
        public UnityEvent onLoadSceneComplete;
        public UnityEvent onUnLoadSceneComplete;

        private AsyncOperation _loadingOperation;
        private AsyncOperation _unLoadingOperation;
    
        public void LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode)
        {
            _loadingOperation = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
            onLoadSceneStarted?.Invoke(_loadingOperation);
            _loadingOperation.completed += OnLoadFinished;
        }

        private void OnLoadFinished(AsyncOperation obj)
        {
            onLoadSceneComplete?.Invoke();
        }

        public void UnLoadSceneAsync(string sceneName)
        {
            _unLoadingOperation = SceneManager.UnloadSceneAsync(sceneName);
            onUnLoadSceneStarted?.Invoke(_unLoadingOperation);
            _unLoadingOperation.completed += OnUnLoadFinished;
        }

        public void ReplaceSceneAsync(string prevScene ,string newScene, LoadSceneMode loadSceneMode)
        {
            UnLoadSceneAsync(prevScene);
            _unLoadingOperation.completed += delegate { LoadSceneAsync(newScene, loadSceneMode); };
        }

        private void OnUnLoadFinished(AsyncOperation obj)
        {
            onUnLoadSceneComplete?.Invoke();
        }
    }
}
