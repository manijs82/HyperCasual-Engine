using UnityEngine;

namespace HyperCasual_Engine.TasksAndDecisions
{
    public class LevelEventInvoked : Decision
    {
        private enum EventType { LevelStarted, LevelEnded, LevelWinner, LevelEndedAsLoser }

        [SerializeField] private LevelManager levelManager;
        [SerializeField] private EventType eventType;
        
        protected override void MakeDecision()
        {
            InvokeDecision(true, stateOnTrue, stateOnFalse);
        }

        protected override void OnGetListener()
        {
            switch (eventType)
            {
                case EventType.LevelStarted:
                    levelManager.OnLevelStart.AddListener(MakeDecision);
                    break;
                case EventType.LevelEnded:
                    levelManager.OnLevelEndedAsLoser.AddListener(MakeDecision);
                    levelManager.OnLevelEndedAsWinner.AddListener(MakeDecision);
                    break;
                case EventType.LevelWinner:
                    levelManager.OnLevelEndedAsWinner.AddListener(MakeDecision);
                    break;
                case EventType.LevelEndedAsLoser:
                    levelManager.OnLevelEndedAsLoser.AddListener(MakeDecision);
                    break;
            }
        }

        protected override void OnLoseListener()
        {
            switch (eventType)
            {
                case EventType.LevelStarted:
                    levelManager.OnLevelStart.RemoveListener(MakeDecision);
                    break;
                case EventType.LevelEnded:
                    levelManager.OnLevelEndedAsLoser.RemoveListener(MakeDecision);
                    levelManager.OnLevelEndedAsWinner.RemoveListener(MakeDecision);
                    break;
                case EventType.LevelWinner:
                    levelManager.OnLevelEndedAsWinner.RemoveListener(MakeDecision);
                    break;
                case EventType.LevelEndedAsLoser:
                    levelManager.OnLevelEndedAsLoser.RemoveListener(MakeDecision);
                    break;
            }
        }
    }
}