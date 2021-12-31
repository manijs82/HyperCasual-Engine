using System;
using UnityEngine;

namespace HyperCasual_Engine
{
    public abstract class Task : MonoBehaviour
    {
        public event Action OnTaskEnded;

        protected bool canPerformTask = true;
        
        public abstract void PerformTask();

        protected void InvokeTaskEnd() =>
            OnTaskEnded?.Invoke();
    }
}