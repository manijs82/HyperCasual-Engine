using UnityEngine;

namespace HyperCasual_Engine.Spawner
{
    [System.Serializable]
    public abstract class SpawnObject
    {
        public Transform location;
        public Direction facingDirection;

        public abstract void Spawn();
    }
}