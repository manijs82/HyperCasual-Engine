using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    [RequireComponent(typeof(Collider))]
    public class DamageOnTouch : MonoBehaviour
    {
        [SerializeField] private int damage = 1;
        [SerializeField] private bool destroyOnTouch;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            OnTouch(other.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTouch(other.gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            OnTouch(other.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            OnTouch(other.gameObject);
        }

        protected virtual void OnTouch(GameObject go)
        {
            DamageObject(go);

            if (destroyOnTouch)
            {
                Destroy(gameObject);
            }
        }

        private void DamageObject(GameObject go)
        {
            Health health = go.GetComponent<Health>();
            if(health == null) return;
            health.Damage(damage);
        }
    }
}