using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class Gun : Weapon
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private Projectile projectile;
        
        public override void Use()
        {
            Instantiate(projectile.gameObject, firePoint.position, Quaternion.LookRotation(firePoint.forward));
        }
    }
}