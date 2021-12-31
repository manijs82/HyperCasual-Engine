using UnityEngine;

namespace HyperCasual_Engine.LevelCreation
{
    public class WayPointHandler : MonoBehaviour
    {
        [SerializeField] private Transform[] wayPoints;

        private int _nextPointIndex;

        public Vector3 GetNextWayPointPosition(out bool wasLastWayPoint)
        {
            var pos = wayPoints[_nextPointIndex].position;
            _nextPointIndex++;
            
            wasLastWayPoint = _nextPointIndex >= wayPoints.Length;

            return pos;
        }
    }
}