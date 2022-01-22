using UnityEngine;

namespace HyperCasual_Engine
{
    public class ScoreAdder : MonoBehaviour
    {
        [SerializeField] private string scoreProfileName;
        [SerializeField] private bool highScore;
        
        public void AddScore(int amount)
        {
            ScoreManager.Instance.AddToScore(scoreProfileName, amount);
        }
        
        public void SetScore(int amount)
        {
            if (highScore)
            {
                if (ScoreManager.Instance.GetScoreValue(scoreProfileName) < amount)
                    ScoreManager.Instance.SetScore(scoreProfileName, amount);
                return;
            }
            ScoreManager.Instance.SetScore(scoreProfileName, amount);
        }
    }
}