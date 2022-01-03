using HyperCasual_Engine.Spawners;
using UnityEngine;

namespace HyperCasual_Engine.TasksAndDecisions
{
    public class WaveEnded : Decision
    {
        [SerializeField] private Spawner spawner;
        
        protected override void MakeDecision()
        {
            InvokeDecision(!spawner.AreAllWavesEnded, stateOnTrue, stateOnFalse);
        }

        protected override void OnGetListener()
        {
            spawner.onWaveEnd.AddListener(MakeDecision);
        }

        protected override void OnLoseListener()
        {
            spawner.onWaveEnd.RemoveListener(MakeDecision);
        }
    }
}