using System.Collections;
using System.Linq;
using UnityEngine;

namespace HyperCasual_Engine.Spawners
{
    public class CharacterWaveSpawner : Spawner
    {
        [Space]
        [SerializeField] private CharacterSpawningWave[] waves;
        
        private void Start()
        {
            if(spawnAtStart)
                Continue();
        }

        public override void Continue()
        {
            Wave nextWave = waves.FirstOrDefault(w => !w.finished);
            
            if (nextWave == null)
            {
                AllWavesEnded();
                WaveEnded();
                return;
            }

            StartCoroutine(StartNextWave(nextWave));
            nextWave.OnWaveEnd += Continue;
        }

        private IEnumerator StartNextWave(Wave spawningWave)
        {
            if(!IsFirstWave(spawningWave))
                WaveEnded();

            yield return new WaitForSeconds(delayBetweenWaves);
            spawningWave.StartWave();
        }

        private bool IsFirstWave(Wave spawningWave) => 
            waves.ElementAt(0) == spawningWave;
    }
}
