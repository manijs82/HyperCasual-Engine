using UnityEngine;

namespace HyperCasual_Engine
{
    public class PauseManager : MonoBehaviour
    {
        public static bool GameIsPaused;

        [SerializeField] private bool setTimeScale = true;
        
        public void PauseGame()
        {
            GameIsPaused = true;
            if(setTimeScale)
                Time.timeScale = 0;
        }
        
        public void ResumeGame()
        {
            GameIsPaused = false;
            if(setTimeScale)
                Time.timeScale = 1;
        }
    }
}