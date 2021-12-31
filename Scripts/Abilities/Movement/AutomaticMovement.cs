using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class AutomaticMovement : MovementAbility
    {
        [SerializeField] private int speed;

        protected override void SetScriptableObjectData()
        {
            if (scriptableObject is AutomaticMovementSo so)
            {
                speed = so.speed;
            }
        }

        protected override void Move()
        {
            transform.Translate(transform.forward * (speed * Time.deltaTime));
        }
    }
}