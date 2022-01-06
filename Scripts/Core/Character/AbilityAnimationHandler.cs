using UnityEngine;

namespace HyperCasual_Engine
{
    [System.Serializable]
    public abstract class AbilityAnimationHandler
    {
        protected Animator targetAnimator;
        protected Ability targetAbility;

        public virtual void Init(Ability ability, Animator animator)
        {
            targetAnimator = animator;
            targetAbility = ability;
            
            InitAnimatorParams();
        }
        
        protected virtual void InitAnimatorParams() { }
    }
}