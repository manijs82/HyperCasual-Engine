using HyperCasual_Engine.Utils;
using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class ToggleableDirectionalMovement : MovementAbility
    {
        [SerializeField] private int speed;
        public Direction[] directions;

        private int _currentDirectionIndex;

        #region Properties

        private int CurrentDirection
        {
            get => _currentDirectionIndex;
            set
            {
                _currentDirectionIndex = value;
                if (_currentDirectionIndex >= directions.Length)
                    _currentDirectionIndex = 0;
                if(CurrentDirection < 0)
                    _currentDirectionIndex = directions.Length;
            }
        }

        #endregion

        public override void Init()
        {
            base.Init();
            
            Owner.InputManager.AddListenerToMouseClick("LeftPressDown", ChangeDirection);
        }
        
        protected override void SetScriptableObjectData()
        {
            if (scriptableObject is ToggleableDirectionalMovementSo so)
            {
                speed = so.speed;
                directions = so.directions;
            }
        }
        
        protected override void Move()
        {
            transform.Translate(directions[_currentDirectionIndex].GetVector3() * (speed * Time.deltaTime));
        }

        private void ChangeDirection()
        {
            CurrentDirection++;
        }

        private void OnDisable()
        {
            Owner.InputManager.RemoveListenerToMouseClick("LeftPressDown", ChangeDirection);
        }
    }
}