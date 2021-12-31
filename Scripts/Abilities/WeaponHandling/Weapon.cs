using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public abstract class Weapon : MonoBehaviour
    {
        public string inputId;
        
        protected WeaponHandler Owner;

        public abstract void Use();

        public virtual Weapon Spawn(WeaponHandler weaponHandler)
        {
            Owner = weaponHandler;
            var go = Instantiate(gameObject, weaponHandler.weaponAttachment);
            go.transform.localPosition = Vector3.zero;
            return go.GetComponent<Weapon>();
        }

        protected virtual void DealDamage(Health health, int amount)
        {
            health.Damage(amount);
        }

    }
}