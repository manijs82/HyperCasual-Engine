using System;
using UnityEngine;

namespace HyperCasual_Engine
{
    public abstract class Decision : MonoBehaviour
    {
        protected event Action<bool, string, string> OnConditionsMet;

        [SerializeField] protected string stateOnTrue;
        [SerializeField] protected string stateOnFalse;

        protected abstract void MakeDecision();
        protected abstract void OnGetListener();
        protected abstract void OnLoseListener();

        public void AddListenerToDecision(Action<bool, string, string> action)
        {
            OnConditionsMet += action;
            OnGetListener();
        }

        public void RemoveListenerToDecision(Action<bool, string, string> action)
        {
            OnLoseListener();
            OnConditionsMet -= action;
        }

        protected void InvokeDecision(bool conditionMet, string stateOnTrue, string stateOnFalse)
        {
            OnConditionsMet?.Invoke(conditionMet, stateOnTrue, stateOnFalse);
        }
    }
}