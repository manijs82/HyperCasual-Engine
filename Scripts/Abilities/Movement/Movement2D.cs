using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class Movement2D : MovementAbility
    {
        [SerializeField] private float acceleration = 1;
        [SerializeField] private float deAcceleration = .5f;
        
        private Vector3 moveDirection;
        private Vector3 velocity;
        
        private float Horizontal => Owner.InputManager.horizontal;
        private float Vertical => Owner.InputManager.vertical;
        
        protected override void Move()
        {
            UpdateVelocity();
            transform.position += velocity * Time.deltaTime;
        }

        private void UpdateVelocity()
        {
            var inputDir = new Vector3(Horizontal, Vertical).normalized;
            moveDirection = inputDir * acceleration;
            velocity += moveDirection;

            velocity -= velocity * deAcceleration;

            velocity = Vector3.ClampMagnitude(velocity, initialSpeed);
        }
    }
}