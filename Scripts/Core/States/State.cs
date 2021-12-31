namespace HyperCasual_Engine
{
    [System.Serializable]
    public struct State
    {
        public string state;
        public Task[] tasks;
        public Decision decision;

        public void OnEnterState(StateMachine stateMachine)
        {
            DoAllTasks();
            if(decision != null)
                decision.AddListenerToDecision(stateMachine.ChangeStateBasedOnDecision);
        }
        
        public void OneExitState(StateMachine stateMachine)
        {
            if(decision != null)
                decision.RemoveListenerToDecision(stateMachine.ChangeStateBasedOnDecision);
        }
        
        public void DoAllTasks()
        {
            foreach (var task in tasks)
            {
                task.PerformTask();
            }
        }

        public override string ToString()
        {
            return state;
        }
    }
}