using HyperCasual_Engine.Utils;
using UnityEngine;

namespace HyperCasual_Engine.Spawners
{
    [System.Serializable]
    public class CharacterSpawnObject : SpawnObject
    {
        public Character character;

        private Character _spawnedCharacter;
        
        public override void Spawn()
        {
            _spawnedCharacter = Object.Instantiate(character, location.position, facingDirection.GetRotation());
        }

        public override Object GetSpawnedObject() => 
            _spawnedCharacter;
    }
}