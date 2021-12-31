using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    [CreateAssetMenu(fileName = "ToggleableDirectionalMovementData", menuName = "HCE/Ability/Toggleable directional movement data")]
    public class ToggleableDirectionalMovementSo : AbilitySo
    {
        public int speed;
        public Direction[] directions;
    }
}