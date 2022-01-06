using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    [System.Serializable]
    public class MovementAnimationHandler : AbilityAnimationHandler
    {
        [SerializeField] private string horizontalMovementAnimationParameter = "HorizontalMovement";
        [SerializeField] private string verticalMovementAnimationParameter = "VerticalMovement";
        
        private static int _horizontalMovementAnimationParameter;
        private static int _verticalMovementAnimationParameter;

        protected override void InitAnimatorParams()
        {
            _horizontalMovementAnimationParameter = Animator.StringToHash(horizontalMovementAnimationParameter);
            _verticalMovementAnimationParameter = Animator.StringToHash(verticalMovementAnimationParameter);
        }

        public void UpdateAnimator(float horizontalMovement, float verticalMovement)
        {
            targetAnimator.SetFloat(_horizontalMovementAnimationParameter, horizontalMovement);
            targetAnimator.SetFloat(_verticalMovementAnimationParameter, verticalMovement);
        }
    }
}