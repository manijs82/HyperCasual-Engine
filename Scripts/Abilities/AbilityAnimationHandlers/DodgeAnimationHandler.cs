using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    [System.Serializable]
    public class DodgeAnimationHandler : AbilityAnimationHandler
    {
        [SerializeField] private string dodgeAnimationParameter = "IsDodging";
        
        private static int _dodgeAnimationParameter;

        protected override void InitAnimatorParams()
        {
            _dodgeAnimationParameter = Animator.StringToHash(dodgeAnimationParameter);
        }

        public void UpdateAnimator(bool isDodging)
        {
            targetAnimator.SetBool(_dodgeAnimationParameter, isDodging);
        }
    }
}