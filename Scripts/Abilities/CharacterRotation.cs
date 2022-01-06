using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class CharacterRotation : AbilityScriptableObjectData
    {
        [SerializeField] private Transform objectToRotate;
        [SerializeField] private RotationMode rotationMode;
        [SerializeField] private RotationSpeed rotationSpeed;

        private MovementAbility _movement;
        private Quaternion _newRotation;

        private Vector3 MoveDirection => _movement.MoveDirection; 

        public override void Init()
        {
            base.Init();
            _movement = Owner.Movement;
        }

        public override void Use()
        {
            switch (rotationMode)
            {
                case RotationMode.None:
                    break;
                case RotationMode.MoveDirection:
                    RotateTowardsMoveDirection();
                    break;
                case RotationMode.MousePosition:
                    RotateTowardsMouseDirection();
                    break;
            }

            objectToRotate.rotation = _newRotation;
        }

        private void RotateTowardsMoveDirection()
        {
            if(MoveDirection != Vector3.zero)
                _newRotation = Quaternion.LookRotation(MoveDirection);
        }

        private void RotateTowardsMouseDirection()
        {
            
        }

        private enum RotationSpeed
        {
            Instant,
            Smooth
        }

        private enum RotationMode
        {
            None,
            MoveDirection,
            MousePosition
        }
    }

    
}