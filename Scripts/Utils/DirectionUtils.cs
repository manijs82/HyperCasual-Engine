using UnityEngine;

namespace HyperCasual_Engine.Utils
{
    public static class DirectionUtils
    {
        public static Vector3 GetVector3(this Direction direction)
        {
            return direction switch
            {
                Direction.North => Vector3.forward,
                Direction.South => Vector3.back,
                Direction.East => Vector3.right,
                Direction.West => Vector3.left,
                _ => Vector3.zero
            };
        }
    }
}