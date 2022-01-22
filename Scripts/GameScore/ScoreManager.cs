using System.Collections.Generic;
using UnityEngine;

namespace HyperCasual_Engine
{
    public class ScoreManager : Singleton<ScoreManager>, ISaveAndLoadData
    {
        [SerializeField] private ScoreProfile[] scoreProfiles;

        private Dictionary<string, int> _scoreValues;

        private void Start()
        {
            Load();
        }

        public void AddToScore(string profileName, int amount) => _scoreValues[profileName] += amount;
        
        public void SetScore(string profileName, int amount) => _scoreValues[profileName] = amount;

        public int GetScoreValue(string profileName) => _scoreValues[profileName];
        
        public void Load()
        {
            _scoreValues = new Dictionary<string, int>();
            foreach (ScoreProfile profile in scoreProfiles)
            {
                _scoreValues.Add(profile.profileName, 0);
            }
        }

        public void Save()
        {
            
        }
    }
}