using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class MovementAbility : AbilityScriptableObjectData
    {
        public float initialSpeed;
        [SerializeField] protected bool useAnimations;
        [SerializeField] protected MovementAnimationHandler movementAnimationHandler;

        [HideInInspector] public float currentSpeed;
        
        public virtual Vector3 MoveDirection => transform.forward;
        public virtual bool IsMoving => false;

        public override void Init()
        {
            base.Init();
            if(useAnimations)
                movementAnimationHandler.Init(this, Owner.characterAnimator);
            currentSpeed = initialSpeed;
        }

        public override void Use()
        {
            if (!UsageAuthorized) return;
            Move();
                
            if(IsMoving && Owner.CurrentState != CharacterState.Moving)
                Owner.ChangeState(CharacterState.Moving);
        }

        protected virtual void Move() { }
        
        protected virtual void UpdateAnimatorHandler() { }
    }
}