using System;
using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class SprintAbility : AbilityScriptableObjectData
    {
        [Min(1)]
        [SerializeField] private float speedMultiplier;

        private MovementAbility _movement;
        private float _previousSpeed;
        
        public override void Init()
        {
            base.Init();
            _movement = Owner.Movement;
            
            Owner.InputManager.AddListenerToButton("StartSprinting", StartSprinting);
            Owner.InputManager.AddListenerToButton("StopSprinting", StopSprinting);
        }

        private void StartSprinting()
        {
            _previousSpeed = _movement.currentSpeed; 
            _movement.currentSpeed *= speedMultiplier;
        }
        
        private void StopSprinting()
        {
            _movement.currentSpeed = _previousSpeed;
        }

        private void OnDisable()
        {
            Owner.InputManager.RemoveListenerToButton("StartSprinting", StartSprinting);
            Owner.InputManager.RemoveListenerToButton("StopSprinting", StopSprinting);
        }
    }
}