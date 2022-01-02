using UnityEngine;
using UnityEngine.Events;

namespace HyperCasual_Engine.Spawners
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] protected bool spawnAtStart;
        [SerializeField] protected float delayBetweenWaves;
        public UnityEvent onAllWavesEnd;
        public UnityEvent onWaveEnd;

        public bool AreAllWavesEnded { get; private set; }

        public virtual void Continue() { }

        protected void AllWavesEnded()
        {
            AreAllWavesEnded = true;
            onAllWavesEnd?.Invoke();
        }
        
        protected void WaveEnded()
        {
            onWaveEnd?.Invoke();
        }
    }
}