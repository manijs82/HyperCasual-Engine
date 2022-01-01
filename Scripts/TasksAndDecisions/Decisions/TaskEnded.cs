using UnityEngine;

namespace HyperCasual_Engine.TasksAndDecisions
{
    public class TaskEnded : Decision
    {
        [SerializeField] private Task task;
        
        protected override void MakeDecision()
        {
            InvokeDecision(true, stateOnTrue, stateOnFalse);
        }

        protected override void OnGetListener()
        {
            task.OnTaskEnded.AddListener(MakeDecision);
        }

        protected override void OnLoseListener()
        {
            task.OnTaskEnded.RemoveListener(MakeDecision);
        }
    }
}