using UnityEngine;
using UnityEngine.Events;

namespace HyperCasual_Engine.Abilities
{
    public class Health : AbilityScriptableObjectData
    {
        [SerializeField] private int initialHealth;
        [SerializeField] private int maxHealth;
        public UnityEvent OnDeath;
        
        private int _health;
        private bool _isDead;

        public override void Init()
        {
            base.Init();
            _health = initialHealth;
        }

        protected override void SetScriptableObjectData()
        {
            if (scriptableObject is HealthSo so)
            {
                initialHealth = so.initialHealth;
                maxHealth = so.maxHealth;
            }
        }

        public void Heal(int amount)
        {
            if(_isDead) return;
            
            _health += amount;

            if (_health > maxHealth)
            {
                _health = maxHealth;
            }
        }

        public void Damage(int amount)
        {
            if(_isDead) return;

            _health -= amount;

            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
        }

        private void Die()
        {
            _isDead = true;
            OnDeath?.Invoke();
            
            Destroy(gameObject);
        }
    }
}