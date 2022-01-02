using UnityEngine;

namespace HyperCasual_Engine.Spawners
{
    [System.Serializable]
    public abstract class SpawnObject
    {
        public Transform location;
        public Direction facingDirection;

        public abstract void Spawn();
        public abstract Object GetSpawnedObject();
    }
}