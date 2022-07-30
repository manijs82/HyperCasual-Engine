using HyperCasual_Engine.Utils.Time;
using UnityEngine;

namespace HyperCasual_Engine.Abilities
{
    public class DodgeAbility : AbilityScriptableObjectData
    {
        [Range(0.3f, 10)]
        [SerializeField] private float cooldown;
        [SerializeField] private float duration;
        [SerializeField] private float distance;
        [SerializeField] private AnimationCurve movingCurve;
        [Space] 
        [SerializeField] private bool useAnimation;
        [SerializeField] private DodgeAnimationHandler animationHandler;

        private MovementAbility _movement;
        private CharacterRotation _rotation;
        private Vector3 moveOrigin;
        private bool _canDodge;
        private float _moveTimer;
        private Countdown _cooldownCountdown;

        public override void Init()
        {
            base.Init();
            
            Owner.InputManager.AddListenerToButton("Dodge", StartDodge);
            _movement = Owner.Movement;
            _rotation = Owner.Rotation;
            animationHandler.Init(this, Owner.characterAnimator);
            _cooldownCountdown = new Countdown(cooldown);
        }

        public override void Use()
        {
            if(_cooldownCountdown.IsTicking)
                _cooldownCountdown.Tick(Time.deltaTime);

            if (_canDodge)
            {
                Dodge();
            }
        }

        private void StartDodge()
        {
            if(!UsageAuthorized) return;
            
            if(_cooldownCountdown.IsTicking) return;
            moveOrigin = transform.position;
            _moveTimer = 0;
            _canDodge = true;
            _cooldownCountdown.Start();
            if(useAnimation)
                animationHandler.UpdateAnimator(true);
            
            Owner.ChangeState(CharacterState.Dodging);
        }

        private void Dodge()
        {
            _moveTimer += Time.deltaTime;

            float moveAmount = movingCurve.Evaluate(_moveTimer / duration) * distance;
            
            transform.position = moveOrigin + _rotation.CurrentDirection * ((_movement.IsMoving ? 1 : -1) * moveAmount);
            
            if (_moveTimer >= duration)
            {
                if(useAnimation)
                    animationHandler.UpdateAnimator(false);
                _canDodge = false;
                Owner.ChangeState(CharacterState.Moving);
            }
        }
    }
}