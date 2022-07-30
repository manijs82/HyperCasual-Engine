using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    [System.Serializable]
    public class MovementAnimationHandler : AbilityAnimationHandler
    {
        [SerializeField] private string horizontalMovementAnimationParameter = "HorizontalMovement";
        [SerializeField] private string verticalMovementAnimationParameter = "VerticalMovement";
        [SerializeField] private string speedAnimationParameter = "Speed";
        [SerializeField] private string isMovingAnimationParameter = "IsMoving";
        
        private static int _horizontalMovementAnimationParameter;
        private static int _verticalMovementAnimationParameter;
        private static int _speedAnimationParameter;
        private static int _isMovingAnimationParameter;

        protected override void InitAnimatorParams()
        {
            _horizontalMovementAnimationParameter = Animator.StringToHash(horizontalMovementAnimationParameter);
            _verticalMovementAnimationParameter = Animator.StringToHash(verticalMovementAnimationParameter);
            _speedAnimationParameter = Animator.StringToHash(speedAnimationParameter);
            _isMovingAnimationParameter = Animator.StringToHash(isMovingAnimationParameter);
        }

        public void UpdateAnimator(float horizontalMovement, float verticalMovement, float speed = 0, bool isMoving = false)
        {
            targetAnimator.SetFloat(_horizontalMovementAnimationParameter, horizontalMovement);
            targetAnimator.SetFloat(_verticalMovementAnimationParameter, verticalMovement);
            targetAnimator.SetFloat(_speedAnimationParameter, speed);
            targetAnimator.SetBool(_isMovingAnimationParameter, isMoving);
        }
    }
}