using System;
using UnityEngine;

namespace HyperCasual_Engine.Spawner
{
    [Serializable]
    public class Wave
    {
        public event Action OnWaveEnd;
        
        [HideInInspector] public bool finished;
        
        public virtual void StartWave() { }

        public virtual void Proceed()
        {
            finished = true;
            OnWaveEnd?.Invoke();
        }
    }
}