using UnityEngine;
using UnityEngine.Events;

namespace HyperCasual_Engine
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private bool startLevelOnStart;
        public UnityEvent OnLevelStart;
        public UnityEvent OnLevelEndedAsWinner;
        public UnityEvent OnLevelEndedAsLoser;

        private bool _levelStarted;
        private float _timeInLevel;

        private void Start()
        {
            if (startLevelOnStart)
                StartLevel();
        }

        public void StartLevel()
        {
            _levelStarted = true;
            OnLevelStart?.Invoke();
        }
        
        public void EndLevel(bool levelWon)
        {
            _levelStarted = false;
            if (levelWon)
            {
                OnLevelEndedAsWinner?.Invoke();
                return;
            }
            OnLevelEndedAsLoser?.Invoke();
        }
    }
}