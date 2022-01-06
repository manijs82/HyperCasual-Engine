using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class MovementAbility : AbilityScriptableObjectData
    {
        public float initialSpeed;
        [SerializeField] protected MovementAnimationHandler movementAnimationHandler;

        [HideInInspector] public float currentSpeed;
        
        public virtual Vector3 MoveDirection => transform.forward;

        public override void Init()
        {
            base.Init();
            movementAnimationHandler.Init(this, Owner.playerAnimator);
            currentSpeed = initialSpeed;
        }

        public override void Use()
        {
            if(UsageAuthorized)
                Move();
        }

        protected virtual void Move() { }
        
        protected virtual void UpdateAnimatorHandler() { }
    }
}