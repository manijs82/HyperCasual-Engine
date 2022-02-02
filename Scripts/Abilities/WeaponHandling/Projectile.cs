using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class Projectile : DamageOnTouch
    {
        [SerializeField] private int speed;

        private void Update()
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
    }
}