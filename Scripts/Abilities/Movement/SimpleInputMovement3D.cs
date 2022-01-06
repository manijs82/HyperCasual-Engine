using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class SimpleInputMovement3D : MovementAbility
    {
        [Space]
        public float speed;
        
        private Vector3 _movementDirection;

        #region Properties

        public override Vector3 MoveDirection => _movementDirection;

        private float Horizontal => Owner.InputManager.horizontal;
        
        private float Vertical => Owner.InputManager.vertical;

        #endregion

        protected override void Move()
        {
            _movementDirection = new Vector3(Horizontal, 0, Vertical)
                .normalized;
            UpdateAnimatorHandler();

            transform.position += _movementDirection * (speed * Time.deltaTime);
        }

        protected override void UpdateAnimatorHandler()
        {
            movementAnimationHandler.UpdateAnimator(MoveDirection.x, MoveDirection.z);
        }
    }
}