using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class CharacterRotation : AbilityScriptableObjectData
    {
        [SerializeField] private RotationMode rotationMode;

        private MovementAbility _movement;
        private Quaternion _newRotation;
        
        public Vector3 CurrentDirection { get; private set; }
        
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

            Owner.characterModel.transform.rotation = _newRotation;
            CurrentDirection = _newRotation * Vector3.forward;
        }

        private void RotateTowardsMoveDirection()
        {
            if(_movement.MoveDirection != Vector3.zero) 
                _newRotation = Quaternion.LookRotation(_movement.MoveDirection);
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