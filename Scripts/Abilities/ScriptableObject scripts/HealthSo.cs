using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    [CreateAssetMenu(fileName = "HealthData", menuName = "HCE/Ability/Health data")]
    public class HealthSo : AbilitySo
    {
        public int initialHealth;
        public int maxHealth;
    }
}