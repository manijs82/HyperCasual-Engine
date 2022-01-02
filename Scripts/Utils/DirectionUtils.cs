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
        
        public static Quaternion GetRotation(this Direction direction)
        {
            return direction switch
            {
                Direction.North => Quaternion.Euler(0, 0, 0),
                Direction.South => Quaternion.Euler(0, 180, 0),
                Direction.East => Quaternion.Euler(0, 90, 0),
                Direction.West => Quaternion.Euler(0, 270, 0),
                _ => Quaternion.identity
            };
        }
    }
}