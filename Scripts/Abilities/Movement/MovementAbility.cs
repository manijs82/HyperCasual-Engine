using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class MovementAbility : AbilityScriptableObjectData
    {
        [SerializeField] protected MovementAnimationHandler movementAnimationHandler;
        
        public virtual Vector3 MoveDirection => transform.forward;

        public override void Init()
        {
            base.Init();
            movementAnimationHandler.Init(this, Owner.playerAnimator);
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