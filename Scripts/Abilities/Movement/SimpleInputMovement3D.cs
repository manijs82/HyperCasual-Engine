using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class SimpleInputMovement3D : MovementAbility
    {
        public float speed;
        
        private Vector3 _movementVector;

        #region Properties

        private float Horizontal => Owner.InputManager.horizontal;
        
        private float Vertical => Owner.InputManager.vertical;

        #endregion

        protected override void Move()
        {
            _movementVector = new Vector3(Horizontal, 0, Vertical)
                .normalized;
            
            transform.Translate(_movementVector * (speed * Time.deltaTime));
        }
    }
}