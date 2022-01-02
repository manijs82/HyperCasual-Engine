using System;
using System.Linq;
using HyperCasual_Engine.Abilities;
using UnityEngine;

namespace HyperCasual_Engine.Spawners
{
    [Serializable]
    public class CharacterSpawningWave : Wave
    {
        public CharacterSpawnObject[] spawnObjects;
        [SerializeField] private bool proceedOnCharacterDeath = true;
        
        private int _deathCount;

        public override void StartWave()
        {
            foreach (var spawnObject in spawnObjects)
            {
                spawnObject.Spawn();
                if (!proceedOnCharacterDeath) continue;

                Character character = spawnObject.GetSpawnedObject() as Character;
                Health health = character.GetAbility<Health>() as Health;
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