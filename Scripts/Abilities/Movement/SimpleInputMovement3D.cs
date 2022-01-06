using System;
using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class SimpleInputMovement3D : MovementAbility
    {
        [Space]
        [SerializeField] private MovementMode movementMode;
        [Range(0,1)]
        [SerializeField] private float acceleration;
        [Range(0,1)]
        [SerializeField] private float startMovingThreshold;
        
        private Vector3 _targetDirection;
        private Vector3 _nextDirection;

        #region Properties

        public override Vector3 MoveDirection => _nextDirection;

        private float Horizontal => Owner.InputManager.horizontal;
        
        private float Vertical => Owner.InputManager.vertical;

        #endregion

        protected override void Move()
        {
            _targetDirection = new Vector3(Horizontal, 0, Vertical);
            DetermineMoveDirection();
            
            _nextDirection = Vector3.MoveTowards(_nextDirection, _targetDirection, acceleration).normalized;

            if(_nextDirection.magnitude > startMovingThreshold)
            {
                transform.position += _nextDirection * (currentSpeed * Time.deltaTime);
            }
            UpdateAnimatorHandler();
        }

        private void DetermineMoveDirection()
        {
            switch (movementMode)
            {
                case MovementMode.Free:
                    break;
                case MovementMode.Strict4Directions:
                    if (Mathf.Abs(_targetDirection.x) > Mathf.Abs(_targetDirection.z))
                        _targetDirection.z = 0f;
                    else
                        _targetDirection.x = 0f;
                    break;
                case MovementMode.Strict8Directions:
                    _targetDirection.x = Mathf.Round(_targetDirection.x);
                    _targetDirection.z = Mathf.Round(_targetDirection.z);
                    break;
                case MovementMode.Strict2HorizontalDirections:
                    _targetDirection.z = 0f;
                    break;
                case MovementMode.Strict2VerticalDirections:
                    _targetDirection.x = 0f;
                    break;
            }
        }

        protected override void UpdateAnimatorHandler()
        {
            movementAnimationHandler.UpdateAnimator(MoveDirection.x, MoveDirection.z);
        }

        private enum MovementMode
        {
            Free,
            Strict4Directions,
            Strict8Directions,
            Strict2HorizontalDirections,
            Strict2VerticalDirections
        }
    }
}