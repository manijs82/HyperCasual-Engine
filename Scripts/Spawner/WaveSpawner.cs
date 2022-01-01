using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace HyperCasual_Engine.Spawner
{
    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private bool spawnAtStart;
        [SerializeField] private float delayBetweenWaves;
        [Space]
        [SerializeField] private Wave[] waves;
        [Space] [SerializeField] private UnityEvent onAllWavesEnd;
        
        private void Start()
        {
            if(spawnAtStart)
                Continue();
        }

        public virtual void Continue()
        {
            Wave nextWave = waves.FirstOrDefault(w => !w.finished);
            
            if (nextWave == null)
            {
                onAllWavesEnd?.Invoke();
                return;
            }

            StartCoroutine(StartNextWave(nextWave));
            nextWave.OnWaveEnd += Continue;
        }

        protected virtual IEnumerator StartNextWave(Wave spawningWave)
        {
            yield return new WaitForSeconds(delayBetweenWaves);
            spawningWave.StartWave();
        }
    }
}
