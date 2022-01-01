using System;
using HyperCasual_Engine.Abilities;
using UnityEngine;

namespace HyperCasual_Engine.Spawner
{
    [Serializable]
    public class CharacterSpawningWave : Wave
    {
        public CharacterSpawnObject[] spawnObjects;
        [SerializeField] private bool proceedOnCharacterDeath;
        
        private int _deathCount;

        public override void StartWave()
        {
            foreach (var spawnObject in spawnObjects)
            {
                spawnObject.Spawn();
                if (!proceedOnCharacterDeath) continue;
                
                Health health = spawnObject.character.GetAbility<Health>() as Health;
                if(health == null)
                    health.OnDeath.AddListener(OnEnemyDeath);
            }
        }

        private void OnEnemyDeath()
        {
            _deathCount++;
            CheckIfAllAreDead();
        }

        private void CheckIfAllAreDead()
        {
            if (_deathCount != spawnObjects.Length) return;
            
            Proceed();
        }
    }
}