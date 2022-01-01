using UnityEngine;
using UnityEngine.Events;

namespace HyperCasual_Engine
{
    public abstract class Task : MonoBehaviour
    {
        public UnityEvent OnTaskEnded;

        protected bool canPerformTask = true;
        
        public abstract void PerformTask();

        protected virtual void OnTaskEnd()
        {
            OnTaskEnded?.Invoke();
        }
    }
}